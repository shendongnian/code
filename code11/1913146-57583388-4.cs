    public class Test  {
        private readonly ILog logger;
        public Test(ILoggerFactory logs)  {
            logger = logs.GetLogger(GetType());
        }
        public void DoSomething(object value) {
            try {
                if (value == null) {
                    throw new Exception();
                }
            } catch (Exception ex) {
                logger.Error("Exception raised!", ex);
            }
        }
    }
