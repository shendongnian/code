    public class MyService
    {
        ILog _logger;
        public MyService(ILog logger)
        {
              _logger = logger;
        }
        public void DoSomething()
        {
             
             _logger.Info("Some info logmessage");
        }
    }
