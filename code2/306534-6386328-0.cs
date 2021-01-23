    public static class Log {
         private static readonly Dictionary<Type, ILog> loggers =
             new Dictionary<Type, ILog>();
         public static void LogInfo(Type type, string message) {
              var logger = Log.GetLoggerForType(type);
              Logger.Info(message);
         }
  
         public static void LogInfo<T>(string message) {
              LogInfo(typeof(T), message);
         }
         private static ILog GetLoggerForType(Type type) {
              ILog logger;
              if(!loggers.TryGetValue(type, out logger)) {
                   logger = LogManager.GetLogger(type);
                   loggers.Add(type, logger);
              }
              return logger;
         }
    }
