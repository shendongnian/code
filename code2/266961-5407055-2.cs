    class ExceptionHandlingTimer
    {
        public event Action<Exception> Error;
        System.Timers.Timer t;
        public ExceptionHandlingTimer(double interval)
        {
            t = new System.Timers.Timer(interval);
        }
        public void Start()
        {
            t.Start();
        }
        public void AddElapsedEventHandler(ElapsedEventHandler handler)
        {
            t.Elapsed += (sender, e) =>
            {
                try
                {
                    handler(sender, e);
                }
                catch (Exception ex)
                {
                    if (Error != null)
                    {
                        Error(ex);
                    }
                    else
                    {
                        throw;
                    }
                }
            };
        }
    }
