    public class WebLoggingHelper
    {
        public static CurrentLineHelper CurrentLine = new CurrentLineHelper();
    
        public class CurrentLineHelper
        {
            private long _counter = 0;
    
            public override string ToString()
            {
                long counter = System.Threading.Interlocked.Increment(ref _counter);
                return counter.ToString();
            }
        }
    }
