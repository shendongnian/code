    public static void Parse( string value , out int number , out string suffix )
    {
      number = 0 ;
      int i = 0 ;
      for ( i = 0 ; i < value.Length && char.IsDigit( value[i] ) ; ++i )
      {
         number *= 10 ;
         number += ( value[i] - '0' ) ;
      }
      suffix = value.Substring(i) ;
      return ;
    }
