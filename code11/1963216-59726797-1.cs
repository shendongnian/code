    public class SignalrRLoggerProvider : ILoggerProvider
    {
        private SignalRLogger _logger;
        private readonly IServiceProvider _sp;
        public SignalrRLoggerProvider(IServiceProvider sp)
        {
            _sp = sp;
        }
        public ILogger CreateLogger(string categoryName)
        {
            if (_logger == null)
            {
                _logger = new SignalRLogger(_sp);
            }
            return _logger;
        }
    }
