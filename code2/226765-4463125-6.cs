    public class A
    {
      private static readonly ILog logger = LogManager.GetLogger("REF");
    
      public void F()
      {
        logger.Info("this message will be tagged with REF");
      }
    }
    
    public class B
    {
      private static readonly ILog logger = LogManager.GetLogger("REF");
    
      public void F()
      {
        logger.Info("this message will be tagged with REF");
      }
    }
    
    public class C
    {
      private static readonly ILog logger = LogManager.GetLogger("UMP");
    
      public void F()
      {
        logger.Info("this message will be tagged with UMP");
      }
    }
