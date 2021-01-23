    public class Typical
    {
      private static readonly ILog logger = 
           LogManager.GetLogger
              (System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
      public void F()
      {
        logger.Info("this message will be tagged with the classname");
      }
    }
