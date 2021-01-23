    public class MyClass
    {
      private static readonly ILog log = LogManager.GetLogger(typeof(MyClass).Name + "." + "Method1");
      private static readonly ILog log2 = LogManager.GetLogger(typeof(MyClass).Name + "." + "Method2");
    
      public void Method1()
      {
        log.info("message");
      }
    
      public void Method2()
      {
        log2.info("message");
      }
    }
