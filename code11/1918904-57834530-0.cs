    class NLogLogger : ILogger
    {
        private readonly NLog.Logger _logger;
    
        public NLogLogger(string name)
        {
            _logger = NLog.LogManager.GetLogger(name);
        }
    
        public void Log(LogEntry entry)
        {
            var nlogLevel = GetNLogLevel(entry.Level);
            if (_logger.IsEnabled(nlogLevel)
            {
               var nlogEvent = NLog.LogEventInfo.Create(nlogLevel, _logger.Name, entry.Message, entry.Ex);
               _logger.Log(typeof(NLogLogger), nlogEvent);
            }
        }
    
        NLog.LogLevel GetNLogLevel(LoggingEventType level)
        {
            switch (level)
            {
               case LoggingEventType.Debug: return NLog.LogLevel.Debug;
               case LoggingEventType.Information: return NLog.LogLevel.Info;
               case LoggingEventType.Warning: return NLog.LogLevel.Warn;
               case LoggingEventType.Error: return NLog.LogLevel.Error;
               case LoggingEventType.Fatal: return NLog.LogLevel.Fatal;
               default: return NLog.LogLevel.Trace;
            }
        }
    }
