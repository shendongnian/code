    class Program
    {
        static void Main()
        {
            Logger.OnLogging += Logger_OnLogging;
            Logger.Log();
            Logger.OnLogging -= Logger_OnLogging;
        }
        static void Logger_OnLogging(LoggingEventArgs e)
        {
            Trace.WriteLine(e.Message);
        }
    }
    public class Logger
    {
        public delegate void LoggingEventHandler(LoggingEventArgs e);
        public static event LoggingEventHandler OnLogging;
        public static void Log()
        {
            // do stuff
            RaiseLoggingEvent("Data logged");
        }
        protected static void RaiseLoggingEvent(string message)
        {
            if (OnLogging != null)
                OnLogging(new LoggingEventArgs(message));
        }
    }
    public class LoggingEventArgs : EventArgs
    {
        public LoggingEventArgs(string message)
        {
            this.Message = message;
        }
        public string Message { get; private set; }
    }
