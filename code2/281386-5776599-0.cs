    public abstract class TimeProvider
    {
        private static TimeProvider current;
        static TimeProvider()
        {
            TimeProvider.current = new DefaultTimeProvider();
        }
        public static TimeProvider Current
        {
            get { return TimeProvider.current; }
    
            set
            {
                if (value == null)      
                {         
                    throw new ArgumentNullException("value");    
                }               2 
                TimeProvider.current = value; 
            }
        }
        public abstract DateTime UtcNow { get; }
        public static void ResetToDefault()
        {
            TimeProvider.current = new DefaultTimeProvider();
        }
    }
