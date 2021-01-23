    [LoggingCategory("LT")]
    public class LogTester
    {
        private static readonly Log4NetLogger Logger = new Log4NetLogger(typeof(LogTester));
    
        public void Test()
        {
            Logger.Debug("This log message should have a prepended category");
        }
    }
