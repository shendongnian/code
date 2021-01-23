    public class Logger
    {
        protected static Logger _logger;
        protected Logger()
        {
            // init
        }
    
        public void Log(string message)
        {
            // log
        }
    
        public static Logger GetLogger()
        {
            return _logger ?? _logger = new Logger();
        }
    }
