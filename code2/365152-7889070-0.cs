    class Log {
        public static void TraceEncrypt(Logger logger, String message) {
            LogEncrypt(logger, LogLevel.Trace, message);
        }
        public static void DebugEncrypt(Logger logger, String message) {
            LogEncrypt(logger, LogLevel.Debug, message);
        }
        public static void InfoEncrypt(Logger logger, String message) {
            LogEncrypt(logger, LogLevel.Info, message);
        }
        public static void WarnEncrypt(Logger logger, String message) {
            LogEncrypt(logger, LogLevel.Warn, message);
        }
        public static void ErrorEncrypt(Logger logger, String message) {
            LogEncrypt(logger, LogLevel.Error, message);
        }
        public static void FatalEncrypt(Logger logger, String message) {
            LogEncrypt(logger, LogLevel.Fatal, message);
        }
        public static void LogEncrypt(Logger logger, LogLevel logLevel, String message) {
            // Prepare log event
            LogEventInfo logEvent = new LogEventInfo(logLevel, logger.Name, message.Encrypt());
            // Log data
            logger.Log(logEvent);
        }
    }
