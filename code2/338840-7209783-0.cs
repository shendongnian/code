    private static int FindIntValueInByteArray( int value , byte[] octets )
    {
      byte[] pattern       = System.BitConverter.GetBytes( value ) ; // get array of 4 octets
      int    matchPosition = -1 ; // assume no match
      
      for ( int i = 0 ; i < octets.Length-3 ; ++i )
      {
        int t = BitConverter.ToInt32( octets , i ) ;
        if ( t == value )
        {
          matchPosition = i ;
          break ;
        }
      }
      
      return matchPosition ;
    }
