    class SynchronousProgress<T> : IProgress<T>
    {
        private readonly Action<T> _action;
        private readonly SynchronizationContext _synchronizationContext;
        public SynchronousProgress(Action<T> action)
        {
            _action = action;
            _synchronizationContext = SynchronizationContext.Current;
        }
        public void Report(T value)
        {
            if (_synchronizationContext != null)
            {
                _synchronizationContext.Send(_ => _action(value), null);
            }
            else
            {
                _action(value);
            }
        }
    }
