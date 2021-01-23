    class MyClass
    {
        private static readonly ILog logger = LogManager.GetLogger(typeof(MyClass));
        void SomeMethod(...)
        {
            logger.Info("some message");
            ...
            if (logger.IsInfoEnabled)
            {
                logger.Info(... something that is expensive to generate ...);
            }
        }
    }
