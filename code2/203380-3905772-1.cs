    public abstract class Message
    {
      public abstract void Process();
    }
    
    public class ExecutionReportMessage : Message
    {
      public override void Process()
      {
        // Do your specific work here.
      }
    }
