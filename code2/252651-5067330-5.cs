    class MyClass
    {
      private static readonly Logger logger = LogManager.GetCurrentClassLogger();
    
      public void DoSomething(int x, int y);
      {
        logger.Info("Doing something.  x = {0}, y = {1}", x, y);
    
        //Or
      
        logger.Log(LogLevel.Info, "Doing something. x = {0}, y = {1}", x, y);
      }
    }
