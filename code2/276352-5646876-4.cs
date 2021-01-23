    public abstract class Logger
    {
        public abstract void Log(LogEntry entry);
        public final void Log(string message)
        {
            this.Log(new LogEntry(LoggingEventType.Information,
                message, null, null));
        }
        public final void Log(Exception exception)
        {
            this.Log(new LogEntry(LoggingEventType.Error, 
                exception.Message, null, exception));
        }
    }
