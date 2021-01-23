    public sealed class LinuxToWindowsFileTimeConverter : IValueConverter
        {
            static long ticksFrom1601To1970 = (long)(new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc) - DateTime.FromFileTimeUtc(0)).Ticks;        
          
            public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
            {                   
                return new DateTime();       
            }        
            
            public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
            {
                return new DateTime();
            }
    
            
            public static DateTime Convert(Int64 nanoSecsSince1970)
            {            
                return Convert(nanoSecsSince1970, ScaleFactor.Billion);
            }
    
            /// <summary>
            /// Converts from Linux seconds to Windows DateTime
            /// </summary>
            /// <param name="secs"></param><remarks> secs</remarks>
            /// <param name="sf"></param><remarks>specifies scale factor.  
            /// Specify ScaleFactor.One for secs since 1970.  
            /// ScaleFactor.Thousand for milli (10^3) seconds since 1970. 
            /// ScaleFactor.Million for micro (10^6)seconds since 1970.
            /// ScaleFactor.Billion for nano (10^9)seconds since 1970.
            /// etc.</remarks>
            /// <returns></returns>
            public static DateTime Convert(Int64 secs, ScaleFactor sf)
            {                                                                   
                long hndrdnsfrom1601 = 0;
    
                switch(sf)
                {                
                    case ScaleFactor.Billion:
                        hndrdnsfrom1601 = ticksFrom1601To1970 + secs / 100;                    
                        break;                
                    default:
                        // TODO:  Correct for other cases.
                        hndrdnsfrom1601 = (long)ticksFrom1601To1970 + (secs * (long)ScaleFactor.TenMillion / (long)sf); 
                        break;
                }
    
                return DateTime.FromFileTimeUtc(hndrdnsfrom1601);                        
            }
    
            public static long ConvertBack(DateTime dateTimeInUTC)
            {
                if (dateTimeInUTC == new DateTime()) 
                    dateTimeInUTC = new DateTime(1980, 1,1).ToUniversalTime();           
    
                long secsSince1970 = (dateTimeInUTC.ToFileTimeUtc() - ticksFrom1601To1970) * ((long)ScaleFactor.Billion / (long)ScaleFactor.TenMillion);           
                return secsSince1970;
            }        
    
            public Int64 ConvertBack(DateTime dateTimeInUTC, CultureInfo culture)
            {
                return ConvertBack(dateTimeInUTC, culture, ScaleFactor.Billion);
            }
    
    
            /// <summary>
            /// Converts from Windows file time to Linux seconds.
            /// </summary>
            /// <param name="dateTimeInUTC"></param>
            /// <param name="culture"></param>
            /// <param name="sf"></param><remarks>
            /// Specify ScaleFactor.One for secs since 1970.  
            /// ScaleFactor.Thousand for milli (10^3) seconds since 1970. 
            /// ScaleFactor.Million for micro (10^6)seconds since 1970.
            /// ScaleFactor.Billion for nano (10^9)seconds since 1970.
            /// </remarks>
            /// <returns></returns>
            public Int64 ConvertBack(DateTime dateTimeInUTC, CultureInfo culture, ScaleFactor sf)
            {
                long secsSince1970 = (dateTimeInUTC.ToFileTimeUtc() - ticksFrom1601To1970) * ((long)sf / (long)ScaleFactor.TenMillion);
                return secsSince1970;
            }
        }
    
        public enum ScaleFactor : long
        { 
            One = 1,
            Ten = 10,
            Hundred = 100,
            Thousand = 1000,
            TenThou = 10000,
            HundredThou = 100000,
            Million = 1000000,
            TenMillion = 10000000,
            HundredMillion = 100000000,
            Billion = 1000000000,
            TenBillion = 10000000000,
            HundredBillion = 100000000000
        }
