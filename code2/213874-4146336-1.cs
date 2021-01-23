    public class MyClass1
    {
      private static readonly TraceSource ts = new TraceSource("MyApplication");
    
      public DoSomething(int x)
      {
        ts.TraceEvent(TraceEventType.Information, "In DoSomething.  x = {0}", x);
      }
    }
    
    public class MyClass2
    {
      private static readonly TraceSource ts = new TraceSource("MyApplication");
    
      public DoSomething(int x)
      {
        ts.TraceEvent(TraceEventType.Information, "In DoSomething.  x = {0}", x);
      }
    }
