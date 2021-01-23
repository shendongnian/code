    public static decimal Truncate( decimal value , int scale )
    {
        Decimal factor = Power(10,scale) ;
        decimal result = value - ( value % factor ) ;
        return result ;
    }
    private static decimal Power( int m , int n )
    {
        if ( m < 1 ) throw new ArgumentOutOfRangeException("m") ;
        Decimal @base  = (decimal) m ;
        Decimal factor = 1m ; // m^0 = 1
        while ( n > 0 )
        {
            factor *= @base ;
            --n ;
        }
        while ( n < 0 )
        {
            factor /= @base ;
            ++n ;
        }
        return factor ;
    }
