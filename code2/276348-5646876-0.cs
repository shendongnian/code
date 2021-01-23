    public static class LoggerExtensions
    {
        public static void Log(this ILogger logger, string message)
        {
            Condition.Requires(logger, "logger").IsNotNull();
            Condition.Requires(message, "message").IsNotNullOrEmpty();
            logger.Log(new LogEntry(LoggingEventType.Information,
                message, null, null));
        }
        public static void Log(this ILogger logger, Exception exception)
        {
            Condition.Requires(logger, "logger").IsNotNull();
            Condition.Requires(exception, "exception").IsNotNull();
            string message = string.IsNullOrEmpty(exception.Message) ?
                exception.GetType().Name : exception.Message;
            logger.Log(new LogEntry(LoggingEventType.Error, 
                message, null, exception));
        }
    }
