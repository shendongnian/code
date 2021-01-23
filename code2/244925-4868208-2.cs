    public class FileReader
    {
      private static TraceSource ts = new TraceSource("Read");
    
      public F()
      {
        ts.Information("Hello from FileReader.F");
      }
    }
    
    public class NetworkReader
    {
      private static TraceSource ts = new TraceSource("Read");
    
      public F()
      {
        ts.Information("Hello from NetworkReader.F");
      }
    }
