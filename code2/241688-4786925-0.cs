    private static readonly Regex rxInternaWhitespace = new Regex( @"\s+" ) ;
    private static readonly Regex rxLeadingTrailingWhitespace = new Regex(@"(^\s+|\s+$)") ;
    public static string Hyphenate( this string s )
    {
      s = rxInternalWhitespace.Replace( s , "-" ) ;
      s = rxLeadingTrailingWhitespace.Replace( s , "" ) ;
      return s ;
    }
