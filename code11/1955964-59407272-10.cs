    public class A
    {
       private readonly Lazy<string> _lazyStr;
    
       public A()
       {
          // Provide a factory method
          _lazyStr = new Lazy<string>(() => CalculateStr());
       }
       public string GetStr()
       {
          // Lazy retrieval of the value, invokes factory if needed.
          return _lazyStr.Value;
       }
       public string CalculateStr()
       {
          // Expensive method goes here. Track to ensure method only called once.
          Console.WriteLine("Called");
    	  return "Foo";
       }
    }
