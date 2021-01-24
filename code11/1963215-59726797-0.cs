    public class SignalRLogger : ILogger
    {
        private readonly IServiceProvider _sp;
        public SignalRLogger(IServiceProvider sp)
        {
            _sp = sp;
        }
        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state, Exception exception, Func<TState, Exception, string> formatter)
        {
            var hub = _sp.GetService<IHubContext<LogHub>>();
            if (hub != null)
            {
                var msg = $"[{logLevel}] {formatter(state, exception)}";
                hub.Clients.All.SendAsync("ReceiveMessage", msg);
            }
        }
    }
