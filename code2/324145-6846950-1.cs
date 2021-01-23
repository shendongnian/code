    public class MyCode
    {
        private IMyLogger _logger = null;
        public MyCode(IMyLogger logger)
        {
            _logger = logger;
        }
    
        public void Do()
        {
            _logger.TraceWriteLine("WOO!");
        }
    }
