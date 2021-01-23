    public class YourCode
    {
      private BlockingCollection<object> queue = new BlockingCollection<object>();
    
      public YourCode()
      {
        var thread = new Thread(StartConsuming);
        thread.IsBackground = true;
        thread.Start();
      }
    
      public void Produce(object item)
      {
        queue.Add(item);
      }
    
      private void StartConsuming()
      {
        while (true)
        {
          object item = queue.Take();
          // Add your code to process the item here.
          // Do not start another task or thread. 
        }
      }
    }
