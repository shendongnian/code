    public enum TimeUnit
    {
       Second,
       Minute,
       Hour,
       Day,
       Year,
       /* etc */
    }
    public static class TimeUnitExtensions
    {
        public static long InTicks(this TimeUnit myUnit)
        {
             switch(myUnit)
             {
               case TimeUnit.Second:
                   return TimeSpan.TicksPerSecond;
               case TimeUnit.Minute:
                   return TimeSpan.TicksPerMinute;
                /* etc */
             }
        }
    }
