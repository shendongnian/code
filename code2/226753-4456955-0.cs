    public class Log4NetLogger
    {
        private readonly ILog _logger;
    
        public Log4NetLogger(Type type)
        {
            _logger = LogManager.GetLogger(type);
        }
    
        private static string GetCategory()
        {
            var attributes = new StackFrame(2).GetMethod().DeclaringType.GetCustomAttributes(typeof(LoggingCategoryAttribute), false);
            if (attributes.Length == 1)
            {
                var attr = (LoggingCategoryAttribute)attributes[0];
                return attr.Category;
            }
            return string.Empty;
        }
    
        public void Debug(string message)
        {
            if(_logger.IsDebugEnabled) _logger.Debug(string.Format("[{0}] {1}", GetCategory(), message));
        }
    }
