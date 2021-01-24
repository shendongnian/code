    public class MyDoer : IMyDoer
    {
        private readonly ILogger logger;
    
        public MyDoer(ILoggerFactory loggerFactory)
        {
            this.logger = loggerFactory.CreateLogger("YourCategory");
        }
        // ...
    }
