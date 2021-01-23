    static readonly Regex rx = new Regex( @"[^\d]*((0*)([1-9][0-9]*)?)" ) ;
    public static IEnumerable<string> ParseNumbers( string s )
    {
      for ( Match matched = rx.Match(s) ; matched.Success ; matched = matched.NextMatch() )
      {
        if ( matched.Groups[1].Length > 0 )
        {
          yield return matched.Groups[3].Value ;
        }
      }
    }
        
