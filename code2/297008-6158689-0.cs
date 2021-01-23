    public static DateTime ToExactMillisecondPrecision( DateTime dt )
    {
      const long TICKS_PER_MILLISECOND = 10000 ;
      long       totalMilliseconds     = dt.Ticks / TICKS_PER_MILLISECOND ;
      return new DateTime( totalMilliseconds * TICKS_PER_MILLISECOND ) ;
    }
