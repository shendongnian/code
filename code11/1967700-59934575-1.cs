    public class WpfDispatcher : IDispatcher
    {
        private readonly Dispatcher _dispatcher;
        public WpfDispatcher(Dispatcher dispatcher) =>
            _dispatcher = dispatcher;
        public bool CheckAccess() => _dispatcher.CheckAccess();
        public void Invoke(Action action) => _dispatcher.Invoke(action);
    }
