    class Logger : ILogger
    {
        public void Log(LoggableEventBase eventToLog)
        {
            Write(eventToLog.Serialize());
        }
        protected virtual void Write(string message)
        {
            //Write the message to a log file
        }
    }
