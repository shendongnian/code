    namespace Microsoft.Extensions.Logging
    {
    
        public static class LoggerExtension
        {
            /// <summary>
            /// Gets the current log level
            /// </summary>
            /// <param name="logger"></param>
            /// <returns>The most restrictive LogLevel that is used</returns>
            public static LogLevel GetLogLevel(this ILogger logger)
            {
                if (logger is null)
                {
                    throw new System.ArgumentNullException(nameof(logger));
                }
    
                var levels=new []{LogLevel.Critical,  LogLevel.Error, LogLevel.Warning, LogLevel.Information,LogLevel.Debug,LogLevel.Trace};
                foreach (var level in levels)
                {
                    if (logger.IsEnabled(level))
                        return level;
                }
                return LogLevel.None;        
            }
        }
    }
