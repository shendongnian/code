    public class Example
    {
      private DateTime value = DateTime.MinValue;
    
      public void DoSomething()
      {
        try
        {
          value = DateTime.UtcNow;
        }
        finally
        {
        }
      }
    }
