    public class MyTimerClass
    {
        private object _syncObject = new object();
        // Other methods here which initiate the log file parsing.
        private void OnTimedEvent(object sender, ElapsedEventArgs e)
        {
            if (Monitor.TryEnter(_syncObject) )
            {
                try
                {
                    ParseLogFiles();
                }
                finally
                {
                    Monitor.Exit(_syncObject);
                }
            }
        }
    }
