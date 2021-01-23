    public static int CountDoubles( int[] Xs )
    {
      int n = 0 ;
      for ( int i = 1 ; i < Xs.Length ; ++i )
      {
        n += ( Xs[i-1] == Xs[i] ? 1 : 0 ) ;
      }
      return n ;
    }
