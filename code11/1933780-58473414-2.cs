    /// <summary>
    /// A helper class for initializing Log4Net in the .NET core project.
    /// </summary>
    public static class Log4netExtensions
    {
        public static ILoggerFactory AddLog4Net(this ILoggerFactory factory, LoggingConfig config, MyCustomAppender appender)
        {
            factory.AddProvider(new Log4NetProvider(config, appender));
            return factory;
        }
    }
