    /// <summary>
    /// Writes ASP.net core logs out to the log4net system.
    /// </summary>
    public class Log4NetLogger : ILogger
    {
        private readonly ILog _logger;
        public Log4NetLogger(string name)
        {
            _logger = LogManager.GetLogger(typeof(Log4NetProvider).Assembly, name);
        }
        public IDisposable BeginScope<TState>(TState state)
        {
            return null;
        }
        public bool IsEnabled(LogLevel logLevel)
        {
            switch (logLevel) {
                case LogLevel.Critical:
                    return _logger.IsFatalEnabled;
                case LogLevel.Debug:
                case LogLevel.Trace:
                    return _logger.IsDebugEnabled;
                case LogLevel.Error:
                    return _logger.IsErrorEnabled;
                case LogLevel.Information:
                    return _logger.IsInfoEnabled;
                case LogLevel.Warning:
                    return _logger.IsWarnEnabled;
                default:
                    throw new ArgumentOutOfRangeException(nameof(logLevel));
            }
        }
        public void Log<TState>(LogLevel logLevel, EventId eventId, TState state,
            Exception exception, Func<TState, Exception, string> formatter)
        {
            if (!this.IsEnabled(logLevel)) {
                return;
            }
            if (formatter == null) {
                throw new ArgumentNullException(nameof(formatter));
            }
            string message = null;
            if (null != formatter) {
                message = formatter(state, exception);
            }
            if (!string.IsNullOrEmpty(message) || exception != null) {
                switch (logLevel) {
                    case LogLevel.Critical:
                        _logger.Fatal(message);
                        break;
                    case LogLevel.Debug:
                    case LogLevel.Trace:
                        _logger.Debug(message);
                        break;
                    case LogLevel.Error:
                        _logger.Error(message);
                        break;
                    case LogLevel.Information:
                        _logger.Info(message);
                        break;
                    case LogLevel.Warning:
                        _logger.Warn(message);
                        break;
                    default:
                        _logger.Warn($"Encountered unknown log level {logLevel}, writing out as Info.");
                        _logger.Info(message, exception);
                        break;
                }
            }
        }
