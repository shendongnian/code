    public class Example
    {
        private readonly ILogger _logger;
        public Example(ILoggerFactory loggerFactory)
        {
            _logger = _loggerFactory.CreateLogger(GetType())
        }
    }
    
