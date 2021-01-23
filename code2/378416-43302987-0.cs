    class SleepAwareTimer : IDisposable
    {
        private readonly Timer _timer;
        private TimeSpan _dueTime;
        private TimeSpan _period;
        private DateTime _nextTick;
        private bool _resuming;
        public SleepAwareTimer(TimerCallback callback, object state, TimeSpan dueTime, TimeSpan period)
        {
            _dueTime = dueTime;
            _period = period;
            _nextTick = DateTime.UtcNow + dueTime;
            SystemEvents.PowerModeChanged += _OnPowerModeChanged;
            _timer = new System.Threading.Timer(o =>
            {
                _nextTick = DateTime.UtcNow + _period;
                if (_resuming)
                {
                    _timer.Change(_period, _period);
                    _resuming = false;
                }
                callback(o);
            }, state, dueTime, period);
        }
        private void _OnPowerModeChanged(object sender, PowerModeChangedEventArgs e)
        {
            if (e.Mode == PowerModes.Resume)
            {
                TimeSpan dueTime = _nextTick - DateTime.UtcNow;
                if (dueTime < TimeSpan.Zero)
                {
                    dueTime = TimeSpan.Zero;
                }
                _timer.Change(dueTime, _period);
                _resuming = true;
            }
        }
        public void Change(TimeSpan dueTime, TimeSpan period)
        {
            _dueTime = dueTime;
            _period = period;
            _nextTick = DateTime.UtcNow + _dueTime;
            _resuming = false;
            _timer.Change(dueTime, period);
        }
        public void Dispose()
        {
            SystemEvents.PowerModeChanged -= _OnPowerModeChanged;
            _timer.Dispose();
        }
    }
