    public class SerialAsyncTasker
    {
      private BlockingCollection<Action> m_Queue = new BlockingCollection<Action>();
    
      public SerialAsyncTasker()
      {
        var thread = new Thread(
          () =>
          {
            while (true)
            {
              Action task = m_Queue.Take();
              task();
            }
          });
        thread.IsBackground = true;
        thread.Start();
      }
    
      public void QueueTask(Action task)
      {
        m_Queue.Add(task);
      }
    }
