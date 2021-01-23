    public static class DateTimeExtensions
    {
        
        public static DateTime Round( this DateTime value , TimeSpan unit )
        {
            return Round( value , unit , default(MidpointRounding) ) ;
        }
        
        public static DateTime Round( this DateTime value , TimeSpan unit , MidpointRounding style )
        {
            if ( unit <= TimeSpan.Zero ) throw new ArgumentOutOfRangeException("unit" , "value must be positive") ;
            
            Decimal  units        = (decimal) value.Ticks / (decimal) unit.Ticks ;
            Decimal  roundedUnits = Math.Round( units , style ) ;
            long     roundedTicks = (long) roundedUnits * unit.Ticks ;
            DateTime instance     = new DateTime( roundedTicks ) ;
            
            return instance ;
        }
        
    }
