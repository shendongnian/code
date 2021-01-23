    public class NonReentrantTimer : IDisposable
    {
        private readonly TimerCallback _callback;
        private readonly TimeSpan _period;
        private readonly Timer _timer;
        
        public NonReentrantTimer(TimerCallback callback, object state, TimeSpan dueTime, TimeSpan period)
        {
            _callback = callback;
            _period = period;
            _timer = new Timer(Callback, state, dueTime, DISABLED_TIME_SPAN);
        }
        private void Callback(object state)
        {
            _callback(state);
            try
            {
                _timer.Change(_period, DISABLED_TIME_SPAN);
            }
            catch (ObjectDisposedException timerHasBeenDisposed)
            {
            }
        }
        public void Dispose()
        {
            _timer.Dispose();
        }
    }
