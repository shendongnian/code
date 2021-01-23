    /// <summary>
    /// Wrapper for the LogManager class to allow us to stub the logger
    /// </summary>
    public class Logger
    {
        public static ILogger _logger = null;
    
        /// <summary>
        /// This should be called to get a valid logger.
        /// </summary>
        /// <returns>A valid logger to log issues to file.</returns>
        public static ILogger Logger
        {
            get
            {
                if (_logger == null)
                {
                    _logger = LogManager.GetLogger("logger");
                }
                return _logger
            }
            set
            {
                _logger = value;
            }
        }
    }
