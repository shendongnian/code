    [ServiceContract]
    public interface IYourService
    {
      [OperationContract]
      void QueueStringValue(string value);
    }
    
    [ServiceBehavior(...)]
    public class YourService : IYourService
    {
      private static BlockingCollection<string> s_Queue = new BlockingCollection<string>();
    
      static YourService()
      {
        var thread = new Thread(
          () =>
          {
            while (true)
            {
              string value = s_Queue.Take();
              // Process the string here.
            }
          });
        thread.IsBackground = true;
        thread.Start();
      }
    
      public void QueueStringValue(string value)
      {
        s_Queue.Add(value);
      }
    }
