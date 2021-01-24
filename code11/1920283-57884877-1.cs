    namespace ConsoleApp1
    {
        public enum LogLevel
        {
            Low,
            Medium,
            High
        }
        public sealed class Logger
        {
            public void Log(LogLevel logLevel, string message)
            {
                // ...
            }
        }
        public static class LoggerExt
        {
            public static void Log(this Logger logger, (LogLevel logLevel, string message) args)
            {
                logger.Log(args.logLevel, args.message);
            }
        }
        class Program
        {
            public static void Main()
            {
                var logger = new Logger();
                // ...
                logger.Log(SomeMethod());
            }
            public static (LogLevel logLevel, string message) SomeMethod()
            {
                return (LogLevel.High, "Some message");
            }
        }
    }
