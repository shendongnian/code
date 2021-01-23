    //
    // In this example, tracing in classes A and B is controlled by the "TraceTest" TraceSource
    // in the app.config file.  Tracing in class C is controlled by the "TraceTestTwo"
    // TraceSource in the app.config.
    //
    // In addition to using different TraceSource names, you can also use SourceSwitches 
    // (in the app.config).  See some examples of app.config in the
    // "turning-tracing-off-via-app-config" link below.
    //
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
      //It's ok to use a different instance of TraceSource, but with the same name,
      //in this class, the new instance will be configured based on the params in the
      //app.config file.
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
