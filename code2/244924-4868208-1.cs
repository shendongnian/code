    public class A
    {
      private static TraceSource ts = new TraceSource(System.Reflection.GetCurrentMethod().DeclaringType.ToString();
    
      public F()
      {
        ts.Information("Inside F");
      }
    }
