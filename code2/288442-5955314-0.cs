    public class Example
    {
      private BlockingCollection<string> m_Queue = new BlockingCollection<string>();
    
      public Example()
      {
        var thread = new Thread(Consumer);
        thread.IsBackground = true;
        thread.Start();
      }
    
      public void QueueChangedFile(string filePath)
      {
        m_Queue.Add(filePath);
      }
    
      private void Consumer()
      {
        while (true)
        {
          // The Take method blocks until an item appears in the queue.
          string filePath = m_Queue.Take();
          // Do whatever you need to do with the file here.
        }
      }
    }
