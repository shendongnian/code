     public static DateTime Today
        {
          get
          {
            return DateTime.Now.Date;   // It returns the date part of Now
    
            //Date Property
           // returns same date as this instance, and the time value set to 12:00:00 midnight (00:00:00) 
          }
        }
    
    
        private const long TicksPerMillisecond = 10000L;
        private const long TicksPerDay = 864000000000L;
        private const int MillisPerDay = 86400000;
    
        public DateTime Date
        {
           get
          {
            long internalTicks = this.InternalTicks; // Date this instance is converted to Ticks 
            return new DateTime((ulong) (internalTicks - internalTicks % 864000000000L) | this.InternalKind);  
    // Modulo of TicksPerDay is subtracted - which brings the time to Midnight time 
          }
        }
    
    
         public static DateTime Now
            {
              get
              {
               /* this is why I guess Jon Skeet is recommending to use  UtcNow as you can see in one of the above comment*/
                DateTime utcNow = DateTime.UtcNow;
                
    
                /* After this i guess it is Timezone conversion */
                bool isAmbiguousLocalDst = false;
                long ticks1 = TimeZoneInfo.GetDateTimeNowUtcOffsetFromUtc(utcNow, out isAmbiguousLocalDst).Ticks;
                long ticks2 = utcNow.Ticks + ticks1;
                if (ticks2 > 3155378975999999999L)
                  return new DateTime(3155378975999999999L, DateTimeKind.Local);
                if (ticks2 < 0L)
                  return new DateTime(0L, DateTimeKind.Local);
                else
                  return new DateTime(ticks2, DateTimeKind.Local, isAmbiguousLocalDst);
              }
            }
