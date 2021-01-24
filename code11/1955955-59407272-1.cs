    public class A
    {
       // Provide a factory
       private Lazy<string> lazyStr = new Lazy<string>(() => CalculateStr());
       private A()
       {
       }
       public string GetStr()
       {
          // Lazy retrieval of the value, invokes factory if needed.
          return lazyStr.Value;
       }
    }
