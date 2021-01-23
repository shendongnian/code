        /*
    ** Implementation of the like() SQL function.  This function implements
    ** the build-in LIKE operator.  The first argument to the function is the
    ** pattern and the second argument is the string.  So, the SQL statements:
    **
    **       A LIKE B
    **
    ** is implemented as like(B,A).
    **
    ** This same function (with a different compareInfo structure) computes
    ** the GLOB operator.
    */
        static void likeFunc(
        sqlite3_context context,
        int argc,
        sqlite3_value[] argv
        )
        {
          string zA, zB;
          u32 escape = 0;
          int nPat;
          sqlite3 db = sqlite3_context_db_handle( context );
    
          zB = sqlite3_value_text( argv[0] );
          zA = sqlite3_value_text( argv[1] );
    
          /* Limit the length of the LIKE or GLOB pattern to avoid problems
          ** of deep recursion and N*N behavior in patternCompare().
          */
          nPat = sqlite3_value_bytes( argv[0] );
          testcase( nPat == db.aLimit[SQLITE_LIMIT_LIKE_PATTERN_LENGTH] );
          testcase( nPat == db.aLimit[SQLITE_LIMIT_LIKE_PATTERN_LENGTH] + 1 );
          if ( nPat > db.aLimit[SQLITE_LIMIT_LIKE_PATTERN_LENGTH] )
          {
            sqlite3_result_error( context, "LIKE or GLOB pattern too complex", -1 );
            return;
          }
          //Debug.Assert( zB == sqlite3_value_text( argv[0] ) );  /* Encoding did not change */
    
          if ( argc == 3 )
          {
            /* The escape character string must consist of a single UTF-8 character.
            ** Otherwise, return an error.
            */
            string zEsc = sqlite3_value_text( argv[2] );
            if ( zEsc == null )
              return;
            if ( sqlite3Utf8CharLen( zEsc, -1 ) != 1 )
            {
              sqlite3_result_error( context,
              "ESCAPE expression must be a single character", -1 );
              return;
            }
            escape = sqlite3Utf8Read( zEsc, ref zEsc );
          }
          if ( zA != null && zB != null )
          {
            compareInfo pInfo = (compareInfo)sqlite3_user_data( context );
    #if SQLITE_TEST
    #if !TCLSH
            sqlite3_like_count++;
    #else
            sqlite3_like_count.iValue++;
    #endif
    #endif
            sqlite3_result_int( context, patternCompare( zB, zA, pInfo, escape ) ? 1 : 0 );
          }
        }
    
    
    
    
        /*
        ** Compare two UTF-8 strings for equality where the first string can
        ** potentially be a "glob" expression.  Return true (1) if they
        ** are the same and false (0) if they are different.
        **
        ** Globbing rules:
        **
        **      '*'       Matches any sequence of zero or more characters.
        **
        **      '?'       Matches exactly one character.
        **
        **     [...]      Matches one character from the enclosed list of
        **                characters.
        **
        **     [^...]     Matches one character not in the enclosed list.
        **
        ** With the [...] and [^...] matching, a ']' character can be included
        ** in the list by making it the first character after '[' or '^'.  A
        ** range of characters can be specified using '-'.  Example:
        ** "[a-z]" matches any single lower-case letter.  To match a '-', make
        ** it the last character in the list.
        **
        ** This routine is usually quick, but can be N**2 in the worst case.
        **
        ** Hints: to match '*' or '?', put them in "[]".  Like this:
        **
        **         abc[*]xyz        Matches "abc*xyz" only
        */
        static bool patternCompare(
        string zPattern,            /* The glob pattern */
        string zString,             /* The string to compare against the glob */
        compareInfo pInfo,          /* Information about how to do the compare */
        u32 esc                     /* The escape character */
        )
        {
          u32 c, c2;
          int invert;
          int seen;
          int matchOne = (int)pInfo.matchOne;
          int matchAll = (int)pInfo.matchAll;
          int matchSet = (int)pInfo.matchSet;
          bool noCase = pInfo.noCase;
          bool prevEscape = false;     /* True if the previous character was 'escape' */
          string inPattern = zPattern; //Entered Pattern
    
          while ( ( c = sqlite3Utf8Read( zPattern, ref zPattern ) ) != 0 )
          {
            if ( !prevEscape && c == matchAll )
            {
              while ( ( c = sqlite3Utf8Read( zPattern, ref zPattern ) ) == matchAll
              || c == matchOne )
              {
                if ( c == matchOne && sqlite3Utf8Read( zString, ref zString ) == 0 )
                {
                  return false;
                }
              }
              if ( c == 0 )
              {
                return true;
              }
              else if ( c == esc )
              {
                c = sqlite3Utf8Read( zPattern, ref zPattern );
                if ( c == 0 )
                {
                  return false;
                }
              }
              else if ( c == matchSet )
              {
                Debug.Assert( esc == 0 );         /* This is GLOB, not LIKE */
                Debug.Assert( matchSet < 0x80 );  /* '[' is a single-byte character */
                int len = 0;
                while ( len < zString.Length && patternCompare( inPattern.Substring( inPattern.Length - zPattern.Length - 1 ), zString.Substring( len ), pInfo, esc ) == false )
                {
                  SQLITE_SKIP_UTF8( zString, ref len );
                }
                return len < zString.Length;
              }
              while ( ( c2 = sqlite3Utf8Read( zString, ref zString ) ) != 0 )
              {
                if ( noCase )
                {
                   if( 0==((c2)&~0x7f) )
                    c2 = (u32)sqlite3UpperToLower[c2]; //GlogUpperToLower(c2);
                   if ( 0 == ( ( c ) & ~0x7f ) )
                     c = (u32)sqlite3UpperToLower[c]; //GlogUpperToLower(c);
                  while ( c2 != 0 && c2 != c )
                  {
                    c2 = sqlite3Utf8Read( zString, ref zString );
                    if ( 0 == ( ( c2 ) & ~0x7f ) )
                      c2 = (u32)sqlite3UpperToLower[c2]; //GlogUpperToLower(c2);
                  }
                }
                else
                {
                  while ( c2 != 0 && c2 != c )
                  {
                    c2 = sqlite3Utf8Read( zString, ref zString );
                  }
                }
                if ( c2 == 0 )
                  return false;
                if ( patternCompare( zPattern, zString, pInfo, esc ) )
                  return true;
              }
              return false;
            }
            else if ( !prevEscape && c == matchOne )
            {
              if ( sqlite3Utf8Read( zString, ref zString ) == 0 )
              {
                return false;
              }
            }
            else if ( c == matchSet )
            {
              u32 prior_c = 0;
              Debug.Assert( esc == 0 );    /* This only occurs for GLOB, not LIKE */
              seen = 0;
              invert = 0;
              c = sqlite3Utf8Read( zString, ref zString );
              if ( c == 0 )
                return false;
              c2 = sqlite3Utf8Read( zPattern, ref zPattern );
              if ( c2 == '^' )
              {
                invert = 1;
                c2 = sqlite3Utf8Read( zPattern, ref zPattern );
              }
              if ( c2 == ']' )
              {
                if ( c == ']' )
                  seen = 1;
                c2 = sqlite3Utf8Read( zPattern, ref zPattern );
              }
              while ( c2 != 0 && c2 != ']' )
              {
                if ( c2 == '-' && zPattern[0] != ']' && zPattern[0] != 0 && prior_c > 0 )
                {
                  c2 = sqlite3Utf8Read( zPattern, ref zPattern );
                  if ( c >= prior_c && c <= c2 )
                    seen = 1;
                  prior_c = 0;
                }
                else
                {
                  if ( c == c2 )
                  {
                    seen = 1;
                  }
                  prior_c = c2;
                }
                c2 = sqlite3Utf8Read( zPattern, ref zPattern );
              }
              if ( c2 == 0 || ( seen ^ invert ) == 0 )
              {
                return false;
              }
            }
            else if ( esc == c && !prevEscape )
            {
              prevEscape = true;
            }
            else
            {
              c2 = sqlite3Utf8Read( zString, ref zString );
              if ( noCase )
              {
                if ( c < 0x80 )
                  c = (u32)sqlite3UpperToLower[c]; //GlogUpperToLower(c);
                if ( c2 < 0x80 )
                  c2 = (u32)sqlite3UpperToLower[c2]; //GlogUpperToLower(c2);
              }
              if ( c != c2 )
              {
                return false;
              }
              prevEscape = false;
            }
          }
          return zString.Length == 0;
        }
