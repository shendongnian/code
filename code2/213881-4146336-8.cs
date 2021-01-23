    public class MyClass1
    {
      private static readonly TraceSource ts = new TraceSource("MyClass1");
    
      public DoSomething(int x)
      {
        ts.TraceEvent(TraceEventType.Information, "In DoSomething.  x = {0}", x);
      }
    }
    
    public class MyClass2
    {
      private static readonly TraceSource ts = new TraceSource("MyClass2");
    
      public DoSomething(int x)
      {
        ts.TraceEvent(TraceEventType.Information, "In DoSomething.  x = {0}", x);
      }
    }
