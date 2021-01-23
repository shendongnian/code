    using System;
    using System.Text.RegularExpressions;
    namespace ConsoleApplication11
    {
        class Program
        {
            static int Main( string[] argv )
            {
                double value1 = parseWithRegex(      "+3.1415926E+09" ) ;
                double value2 = parseWithBruteForce( "+3.1415926E+09" ) ;
                return 0 ;
            }
            static Regex rxNumericValue = new Regex( @"
    ^                     # start of line, followed by
    \s*                   # zero or more leading whitespace characters, followed by
    (?<sign>[+-])?        # an optional sign (either '+' or '-'), followed by
    (?<integer>[0-9]+)    # a mandatory integer value (1 or more decimal digits), followed by
    (                     # an optional fraction,
      \.                  #   consisting of a decimal point, followed by
      (?<fraction>[0-9]*) #   zero or more decimal digits
    )?                    # The optional franction is followed by
    (                     # an optional exponent,
      [Ee]                #   consisting of the letter E, followed by
      (?<expsign>[+-])?   #   an optional sign (either '+' or '-'), followed by
      (?<exponent>[0-9]+) #   1 or more decimal digits
    )?                    # The optional exponent is followed by
    \s*                   # zero more more trailing whitespace characters
    " ,
      RegexOptions.IgnorePatternWhitespace|RegexOptions.ExplicitCapture
      );
            /// <summary>
            /// Parse a numeric literal into a double with a regular expression
            /// </summary>
            /// <param name="s"></param>
            /// <returns></returns>
            public static double parseWithRegex( string s )
            {
                if ( s == null ) throw new ArgumentNullException("s") ;
                Match match = rxNumericValue.Match( s ) ;
                if ( !match.Success ) throw new FormatException() ;
                string sign           = match.Groups[ "sign"     ].Value ;
                string integerDigits  = match.Groups[ "integer"  ].Value ;
                string fractionDigits = match.Groups[ "fraction" ].Value ;
                string exponentSign   = match.Groups[ "expsign"  ].Value ;
                string exponentDigits = match.Groups[ "exponent" ].Value ;
                double accumulator    = 0.0 ;
                foreach ( char digit in integerDigits )
                {
                    accumulator *= 10.0 ;
                    accumulator += (digit - '0') ; // assumes codepoints for 0-9 are contiguous
                }
                double factor = 1.0 ;
                foreach ( char digit in fractionDigits )
                {
                    factor      *= 10.0 ;
                    accumulator += ((double)( digit - '0' )) / factor ;
                }
                if ( sign == "-" ) accumulator = - accumulator ;
                int power = 0 ;
                foreach ( char digit in exponentDigits )
                {
                    power *= 10 ;
                    power += ( digit - '0') ;
                }
                if ( exponentSign == "-" ) power = - power ;
                double exponent = Math.Pow( 10.0 , power ) ;
                double value    = accumulator *= exponent ;
                return value ;
            }
            /// <summary>
            /// Parse a numeric literal into a double the old-fashioned way
            /// </summary>
            /// <param name="s"></param>
            /// <returns></returns>
            private static double parseWithBruteForce( string s )
            {
                bool   isNegative         ;
                double accumulator        = 0.0 ;
                int    i                  = 0 ;
                // skip lead-in whitespace
                while ( i < s.Length && char.IsWhiteSpace(s[i]) )
                {
                    ++i ;
                }
                // parse the sign
                if ( i >= s.Length ) throw new FormatException() ;
                switch ( s[i] )
                {
                case '+' : isNegative = false ; ++i ; break ;
                case '-' : isNegative = true  ; ++i ; break ;
                default  : isNegative = false ; break ;
                }
                // parse the integer portion
                if ( i >= s.Length ) throw new FormatException() ;
                bool hasIntegerDigits = false ;
                while ( i < s.Length && char.IsDigit(s[i]) )
                {
                    hasIntegerDigits  = true ;
                    accumulator      *= 10.0 ;
                    accumulator      += ( s[i] - '0') ;
                    ++i ;
                }
                if ( !hasIntegerDigits ) throw new FormatException() ;
                // set the sign
                if ( isNegative ) accumulator = - accumulator ;
                // from this point on, everything is optional
                // parse the fraction, if there is one
                if ( i < s.Length && s[i] == '.' )
                { // got a decimal point
                    ++i ; //gobble the decimal point
                    double factor = 1.0 ;
                    while ( i < s.Length && char.IsDigit(s[i]) )
                    {
                        factor      *= 10.0 ;
                        accumulator += ((double)( s[i] - '0' )) / factor ;
                        ++i ;
                    }
                }
                // parse the exponent, if there is one
                if ( i < s.Length && ( s[i] == 'E' || s[i] == 'e' ) )
                { // found an exponent
                    ++i ; // gobble the 'E'
                    // parse the sign
                    if ( i >= s.Length ) throw new FormatException() ;
                    bool expNegative ;
                    switch ( s[i] )
                    {
                    case '+' : expNegative = false ; ++i ; break ;
                    case '-' : expNegative = true  ; ++i ; break ;
                    default  : expNegative = false ;       break ;
                    }
                    bool hasExponentDigits = false ;
                    int power = 0 ;
                    while ( i < s.Length && char.IsDigit(s[i]) )
                    {
                        hasExponentDigits  = true ;
                        power             *= 10 ;
                        power             += (s[i] - '0') ;
                        ++i ;
                    }
                    if ( !hasExponentDigits ) throw new FormatException() ;
                    if ( expNegative ) power = - power ;
                    double exponent  = Math.Pow(10.0,power) ;
                    accumulator     *= exponent ;
                }
                // skip past any trailing whitespace
                while ( i < s.Length && char.IsWhiteSpace(s[i]) )
                {
                    ++i ;
                }
                // if we're not at end-of-string, we have a syntax error
                if ( i < s.Length ) throw new FormatException() ;
                return accumulator ;
            }
        }
    }
