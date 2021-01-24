            public class CustomLogger : ILogger
            {
                public CustomLogger() { }
                public IDisposable BeginScope<TState>(TState state)=> NullScope.Instance;
                public bool IsEnabled(LogLevel logLevel) => true;
                public void Log<TState>(
                    LogLevel logLevel,
                    EventId eventId,
                    TState state,
                    Exception exception,
                    Func<TState, Exception, string> formatter
                )
                {
                    var msg = formatter(state, exception);
                    if (msg.Contains("404"))
                    {
                        logLevel = LogLevel.Warning;
                    }
                    Console.WriteLine($"{ GetLogLevelString(logLevel) } : { eventId } { msg } { exception }");
                }
                private static string GetLogLevelString(LogLevel logLevel)
                {
                    switch (logLevel)
                    {
                        case LogLevel.Trace:
                            return "trce";
                        case LogLevel.Debug:
                            return "dbug";
                        case LogLevel.Information:
                            return "info";
                        case LogLevel.Warning:
                            return "warn";
                        case LogLevel.Error:
                            return "fail";
                        case LogLevel.Critical:
                            return "crit";
                        default:
                            throw new ArgumentOutOfRangeException(nameof(logLevel));
                    }
                }
            }
