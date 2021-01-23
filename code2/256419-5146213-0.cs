    public class Processor
    {
        private readonly object lockObject = new object();
        public void PerformProcessing()
        {
            if (Monitor.TryEnter(lockObject) == true)
            {
                try
                {
                    // Do something...
                }
                finally
                {
                    Monitor.Exit(lockObject);
                }
            }
        }
    }
