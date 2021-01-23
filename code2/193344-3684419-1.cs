    public sealed class LaggedMethodPair
    {
        private SynchronizationContext _context;
        private Timer _timer;
        private Action _primaryAction;
        private Action _laggedCallback;
        private int _millisecondsLag;
        public LaggedMethodPair(Action primaryAction,
                                Action laggedCallback,
                                int millisecondsLag)
        {
            if (millisecondsLag < 0)
            {
                throw new ArgumentOutOfRangeException("Lag cannot be negative.");
            }
            // Do nothing by default.
            _primaryAction = primaryAction ?? new Action(() => { });
            // Do nothing by default.
            _laggedCallback = laggedCallback ?? new Action(() => { });
            _millisecondsLag = millisecondsLag;
            _timer = new Timer(state => RunTimer());
        }
        public void Invoke()
        {
            // Technically there is a race condition here.
            // It could be addressed, but in practice it will
            // generally not matter as long as Invoke is always
            // being called from the same SynchronizationContext.
            if (SynchronizationContext.Current == null)
            {
                SynchronizationContext.SetSynchronizationContext(
                    new SynchronizationContext()
                );
            }
            _context = SynchronizationContext.Current;
            ResetTimer();
            _primaryAction();
        }
        void ResetTimer()
        {
            _timer.Change(_millisecondsLag, Timeout.Infinite);
        }
        void RunTimer()
        {
            _context.Post(state => _laggedCallback(), null);
        }
    }
