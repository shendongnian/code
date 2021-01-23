    public class MyClass
    {
        private readonly ILogger _logger;
        public MyClass(ILogger logger)
        {
            _logger = logger;
        }
        public void DoStuff()
        {
            _logger.Trace("DoStuff called");
        }
    }
