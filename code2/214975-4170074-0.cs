    public class Logger
    {
        private static List<Logger> _loggers = new List<Logger>();
        private static object _sync = new object();
    
        public static void Start()
        {
            Logger logger = new Logger();
            logger.Start();
    
            lock (_sync) {
                _loggers.Add( logger );
            }
        }
    
        private Logger()
        {
            // construct the Logger object...
        }
    
        private void Start()
        {
            // start the logger here...
        }
    }
    
    public class LoggingService : ILoggingService
    {
        public void StartLogger()
        {
            Logger.Start();
        }
    }
