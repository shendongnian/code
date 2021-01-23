      class NLogLogger : ILogger
      {
        private NLog.Logger logger;
    
        //The Type that is passed in is ultimately the type of the current object that
        //Ninject is creating.  In the case of my example, it is Class1 and Class1 is
        //dependent on ILogger.
        public NLogLogger(Type t)
        {
          logger = NLog.LogManager.GetLogger(t.FullName);
        }
    
        //Trace, Warn, Error, Fatal eliminated for brevity
    
        public bool IsInfoEnabled
        {
          get { return logger.IsInfoEnabled; }
        }
    
        public bool IsDebugEnabled
        {
          get { return logger.IsDebugEnabled; }
        }
    
        public void Info(string format, params object [] args)
        {
          if (logger.IsInfoEnabled)
          {
            Write(LogLevel.Info, format, args);
          }
        }
    
        public void Debug(string format, params object [] args)
        {
          if (logger.IsDebugEnabled)
          {
            Write(LogLevel.Debug, format, args);
          }
        }
    
        private void Write(LogLevel level, string format, params object [] args)
        {
          LogEventInfo le = new LogEventInfo(level, logger.Name, null, format, args);
          logger.Log(typeof(NLogLogger), le);
        }
      }
