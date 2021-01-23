    public class A
    {
      private static readonly TraceSource ts = new TraceSource("TraceTest");
      
      public void DoSomething()
      {
        ts.TraceEvent(TraceEventType.Warning, 2, "File Test not found");   
      }
    }
    
    public class B
    {
      //
      //Use the same config info for TraceTest in this class
      //It's ok to use a different instance of TraceSource in this class, the new
      //instance will be configured based on the params in the app.config file.
      //
      private static readonly TraceSource ts = new TraceSource("TraceTest");
      
      public void DoSomething()
      {
        ts.TraceEvent(TraceEventType.Warning, 2, "File Test not found");   
      }
    }
    
    public class C
    {
      //
      //Use a different TraceSource in this class.
      //
      private static readonly TraceSource ts = new TraceSource("TraceTestTwo");
      
      public void DoSomething()
      {
        ts.TraceEvent(TraceEventType.Warning, 2, "File Test not found");   
      }
    }
