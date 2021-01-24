    public class Demo
        {
            private readonly ILogger<Demo> _logger;
    
            public Demo(IILogger<Demo> logger)
            {
                // Use _logger throughout the class
                _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            }
    
            public void Log()
            {
                // _logger.Log(message);
            }
        }
