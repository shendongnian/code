    /// <summary>
    /// Provides an extension for the log4net libraries to provide ansynchronous logging capabilities to the log4net architecture
    /// </summary>
    public class AsyncLogFileAppender : log4net.Appender.ForwardingAppender
    {
        private static int _asyncLogFileAppenderCount = 0;
        private readonly Thread _loggingThread;
        private readonly BlockingCollection<log4net.Core.LoggingEvent> _logEvents = new BlockingCollection<log4net.Core.LoggingEvent>();
    
        protected override void Append(log4net.Core.LoggingEvent loggingEvent)
        {
            loggingEvent.Fix = FixFlags.ThreadName;
            _logEvents.Add(loggingEvent);
        }
    
        public AsyncLogFileAppender()
        {
     
            _loggingThread = new Thread(LogThreadMethod) { IsBackground = true, Name = "AsyncLogFileAppender-" + Interlocked.Increment(ref _asyncLogFileAppenderCount), };
            _loggingThread.Start();
        }
    
        private void LogThreadMethod()
        {
            while (true)
            {
                LoggingEvent le = _logEvents.Take();
                foreach (var appender in Appenders)
                {
                    appender.DoAppend(le);
                }
            }
        }
    }
