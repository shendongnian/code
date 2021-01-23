    public class ThreadTimer
    {
        private readonly ThreadStart realWork;
        public ThreadTimer(ThreadStart realWork)
        {
            this.realWork = realWork;
        }
        public void TimeAndExecute()
        {
            Stopwatch stopwatch = Stopwatch.StartNew();
            try
            {
                realWork();
            }
            finally
            {
                stopwatch.Stop();
                // Log or whatever here
            }
        }
    }
