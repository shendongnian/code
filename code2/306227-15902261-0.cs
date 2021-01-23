    class TimerHelper
    {
        private Timer _timer;
        private readonly object _threadLock = new object();
    
        public void Start(TimeSpan timerInterval)
        {
            Stop();
            _timer = new Timer(Timer_Elapsed, null, 0, (long)timerInterval.TotalMilliseconds);
        } 
    
        public void Stop()
        {
            // Wait for timer queue to be emptied, before we continue (Timer threads should have left the callback method given)
            // - http://woowaabob.blogspot.dk/2010/05/properly-disposing-systemthreadingtimer.html
            // - http://blogs.msdn.com/b/danielvl/archive/2011/02/18/disposing-system-threading-timer.aspx
            lock (_threadLock)
            {
                if (_timer!= null)
                {
                    WaitHandle waitHandle = new AutoResetEvent(false);
                    _timer.Dispose(waitHandle);
                    WaitHandle.WaitAll(new[] { waitHandle }, TimeSpan.FromMinutes(2) );
                    _timer = null;
                }
            }
        }
    
        void Timer_Elapsed(object state)
        {
            // Ensure that we don't have multiple timers active at the same time
            if (Monitor.TryEnter(_threadLock))
            {
                try
                {
                    // Do what you want to do
                }
                finally
                {
                    Monitor.Exit(_threadLock);
                }
            }
        }
    }
