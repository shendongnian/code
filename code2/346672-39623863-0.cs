      public  class NlogWrapper 
        {  
            private  readonly NLog.Logger _logger; //NLog logger
        /// <summary>
        /// This is the construtor, which get the correct logger name when instance created  
        /// </summary>
       
        public NlogWrapper()
            {
            StackTrace trace = new StackTrace();
            if (trace.FrameCount > 1)
            {
                _logger = LogManager.GetLogger(trace.GetFrame(1).GetMethod().ReflectedType.FullName);
            }
            else //This would go back to the stated problem
            {
                _logger = LogManager.GetCurrentClassLogger();
            }
        }
        /// <summary>
        /// These two method are used to retain the ${callsite} for all the Nlog method  
        /// </summary>
        /// <param name="level">LogLevel.</param>
        ///  <param name="format">Passed message.</param>
        ///  <param name="ex">Exception.</param>
        private void Write(LogLevel level, string format, params object[] args)
        {
            LogEventInfo le = new LogEventInfo(level, _logger.Name, null, format, args);
            _logger.Log(typeof(NlogWrapper), le);
        }
        private void WriteWithEx(LogLevel level, string format,Exception ex, params object[] args)
        {
            LogEventInfo le = new LogEventInfo(level, _logger.Name, null, format, args);
            le.Exception = ex;
            _logger.Log(typeof(NlogWrapper), le);
        }
        #region  Methods
        /// <summary>
        /// This method writes the Debug information to trace file
        /// </summary>
        /// <param name="message">The message.</param>
        public  void Debug(String message)
            {
                if (!_logger.IsDebugEnabled) return;
            Write(LogLevel.Debug, message);
        }  
        public  void Debug(string message, Exception exception, params object[] args)
        {
            if (!_logger.IsFatalEnabled) return;
            WriteWithEx(LogLevel.Debug, message, exception);
        }
        /// <summary>
        /// This method writes the Information to trace file
        /// </summary>
        /// <param name="message">The message.</param>
        public  void Info(String message)
            {
                if (!_logger.IsInfoEnabled) return;
            Write(LogLevel.Info, message);
        }
        public  void Info(string message, Exception exception, params object[] args) 
        {
            if (!_logger.IsFatalEnabled) return;
            WriteWithEx(LogLevel.Info, message, exception);
        }
        /// <summary>
        /// This method writes the Warning information to trace file
        /// </summary>
        /// <param name="message">The message.</param>
        public  void Warn(String message)
            {
                if (!_logger.IsWarnEnabled) return;
              Write(LogLevel.Warn, message); 
            }
        public  void Warn(string message, Exception exception, params object[] args)
        {
            if (!_logger.IsFatalEnabled) return;
            WriteWithEx(LogLevel.Warn, message, exception);
        }
        /// <summary>
        /// This method writes the Error Information to trace file
        /// </summary>
        /// <param name="error">The error.</param>
        /// <param name="exception">The exception.</param>
        //   public static void Error( string message)
        //  {
        //    if (!_logger.IsErrorEnabled) return;
        //  _logger.Error(message);
        //}
        public  void Error(String message) 
        {
            if (!_logger.IsWarnEnabled) return;
            //_logger.Warn(message);
            Write(LogLevel.Error, message);
        }
        public void Error(string message, Exception exception, params object[] args)
        {
            if (!_logger.IsFatalEnabled) return;
            WriteWithEx(LogLevel.Error, message, exception);
        }  
        /// <summary>
        /// This method writes the Fatal exception information to trace target
        /// </summary>
        /// <param name="message">The message.</param>
        public void Fatal(String message)
            {
                if (!_logger.IsFatalEnabled) return;
             Write(LogLevel.Fatal, message);
        }
        public void Fatal(string message, Exception exception, params object[] args)
        {
            if (!_logger.IsFatalEnabled) return;
            WriteWithEx(LogLevel.Fatal, message, exception);
        }
        /// <summary>
        /// This method writes the trace information to trace target
        /// </summary>
        /// <param name="message">The message.</param>
        /// 
        public  void Trace(string message, Exception exception, params object[] args)  
        {
            if (!_logger.IsFatalEnabled) return;
            WriteWithEx(LogLevel.Trace, message, exception);
        }
        public  void Trace(String message)
            {
                if (!_logger.IsTraceEnabled) return;
                Write(LogLevel.Trace, message);
        }
            #endregion
        }
