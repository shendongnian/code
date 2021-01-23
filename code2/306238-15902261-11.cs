    class TimerHelper : IDisposable
    {
        private System.Threading.Timer _timer;
        private readonly object _threadLock = new object();
    
        public event Action<Timer,object> TimerEvent;
    
        public void Start(TimeSpan timerInterval, bool triggerAtStart = false, object state = null)
        {
            Stop();
            _timer = new System.Threading.Timer(Timer_Elapsed, state, System.Threading.Timeout.Infinite, System.Threading.Timeout.Infinite);
            if (triggerAtStart)
                _timer.Change(TimeSpan.FromTicks(0), timerInterval);
            else
                _timer.Change(timerInterval, timerInterval);
        }
    
        public void Stop()
        {
            // Wait for timer queue to be emptied, before we continue (Timer threads should have left the callback method given)
            // - http://woowaabob.blogspot.dk/2010/05/properly-disposing-systemthreadingtimer.html
            // - http://blogs.msdn.com/b/danielvl/archive/2011/02/18/disposing-system-threading-timer.aspx
            lock (_threadLock)
            {
                if (_timer != null)
                {
                    WaitHandle waitHandle = new AutoResetEvent(false);
                    _timer.Dispose(waitHandle);
                    WaitHandle.WaitAll(new[] { waitHandle }, TimeSpan.FromMinutes(2));
                    _timer = null;
                }
            }
        }
    
        public void Dispose()
        {
            Stop();
            TimerEvent = null;
        }
  
        void Timer_Elapsed(object state)
        {
            // Ensure that we don't have multiple timers active at the same time
            // - Also prevents ObjectDisposedException when using Timer-object inside this method
            // - Maybe consider to use _timer.Change(interval, Timeout.Infinite) (AutoReset = false)
            if (Monitor.TryEnter(_threadLock))
            {
                try
                {
                    Action<Timer, object> timerEvent = TimerEvent;
                    if (timerEvent != null)
                    {
                        timerEvent(_timer, state);
                    }
                }
                finally
                {
                    Monitor.Exit(_threadLock);
                }
            }
        }
    }
