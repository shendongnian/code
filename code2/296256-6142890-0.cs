    static string FormatAsPhoneNumber( string s )
    {
      if ( s == null ) throw new ArgumentNullException() ;
      if ( s.Length > 10 ) throw new ArgumentOutOfRangeException() ;
      
      StringBuilder sb = new StringBuilder() ;
      int           p  = 0 ;
      int           remaining = s.Length ;
      
      if ( remaining > 7 )
      {
        int areaCodeLength = remaining - 7 ;
        
        sb.Append("(").Append(s.Substring(p,areaCodeLength)).Append(") ") ;
        
        p         += areaCodeLength ;
        remaining -= areaCodeLength ;
        
      }
      if ( remaining > 4 )
      {
        int exchangeLength = remaining - 4 ;
        
        sb.Append(s.Substring(p,exchangeLength)).Append("-") ;
        
        p         += exchangeLength ;
        remaining -= exchangeLength ;
        
      }
      
      sb.Append(s.Substring(p) ) ;
      
      string formatted = sb.ToString() ;
      return formatted ;
    }
