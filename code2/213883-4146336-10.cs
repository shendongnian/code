    public class Analysis1
    {
      private static readonly TraceSource ts = new TraceSource("MyApplication.Analysis");
    
      public DoSomething(int x)
      {
        ts.TraceEvent(TraceEventType.Information, "In DoSomething.  x = {0}", x);
      }
    }
    
    public class Analysis2
    {
      private static readonly TraceSource ts = new TraceSource("MyApplication.Analysis");
    
      public DoSomething(int x)
      {
        ts.TraceEvent(TraceEventType.Information, "In DoSomething.  x = {0}", x);
      }
    }
    
    public class DataAccess1
    {
      private static readonly TraceSource ts = new TraceSource("MyApplication.DataAccess");
    
      public DoSomething(int x)
      {
        ts.TraceEvent(TraceEventType.Information, "In DoSomething.  x = {0}", x);
      }
    }
    
    public class DataAccess2
    {
      private static readonly TraceSource ts = new TraceSource("MyApplication.DataAccess");
    
      public DoSomething(int x)
      {
        ts.TraceEvent(TraceEventType.Information, "In DoSomething.  x = {0}", x);
      }
    }
