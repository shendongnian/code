    public enum TimeUnit
    {
       Second,
       Minute,
       Hour,
       Day,
       Year
       ...
    }
    public static TimeUnitExtensions
    {
        public static long InTicks(this TimeUnit myUnit)
        {
             switch(myUnit)
               case TimeUnit.Second:
                   return TimeSpan.TicksPerSecond;
               case TimeUnit.Minute:
                   return TimeSpan.TicksPerMinute;
              ....
        }
    }
