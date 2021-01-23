    public class MyClass : IDisposable
    {
      private BlockingCollection<string> m_Queue = new BlockingCollection<string>();
    
      public class MyClass()
      {
        var thread = new Thread(Process);
        thread.IsBackground = true;
        thread.Start();
      }
      public void Dispose()
      {
        m_Queue.Add(null);
      }
    
      public void AddTask(string item)
      {
        if (item == null)
        {
          throw new ArgumentNullException();
        }
        m_Queue.Add(item);
      }
    
      private void Process()
      {
        while (true)
        {
          string item = m_Queue.Take();
          if (item == null)
          {
            break; // Gracefully end the consumer thread.
          }
          else
          {
            // Process the item here.
          }
        }
      }
    }
