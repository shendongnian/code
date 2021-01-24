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
          Console.WriteLine("Called");
    	  return "Foo";
       }
    }
