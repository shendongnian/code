    public class TimeOfDay
    {
        public int Hours{get;set;}
        public int Minutes{get;set;}
        
        //possibly even
        public TimeSpan TimeSpan
        {
            get
            {
                return new TimeSpan(new DateTime(2000,1,1,Hours,Minutes,0).Ticks -new DateTime(2000,1,1).Ticks);
            }
        }
    }
