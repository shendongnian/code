    /// <summary>
    /// Returns new log4net loggers when called by the ASP.net core logging framework
    /// </summary>
    public class Log4NetProvider : ILoggerProvider
    {
        private readonly LoggingConfig _config;
        private readonly ConcurrentDictionary<string, Log4NetLogger> _loggers =
            new ConcurrentDictionary<string, Log4NetLogger>();
        private readonly ILoggerRepository _repository =
            log4net.LogManager.CreateRepository(typeof(Log4NetProvider).Assembly, typeof(log4net.Repository.Hierarchy.Hierarchy));
        public Log4NetProvider(LoggingConfig config, MyCustomAppender otherAppender)
        {
            _config = config;
            BasicConfigurator.Configure(_repository, new ConsoleAppender(), otherAppender);
            LogManager.GetLogger(this.GetType()).Info("Logging initialized.");
        }
        public ILogger CreateLogger(string categoryName)
        {
            return _loggers.GetOrAdd(categoryName, this.CreateLoggerImplementation(categoryName));
        }
        public void Dispose()
        {
            _loggers.Clear();
        }
        private Log4NetLogger CreateLoggerImplementation(string name)
        {
            return new Log4NetLogger(name);
        }
    }
