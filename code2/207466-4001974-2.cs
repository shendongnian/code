    public class Example
    {
      private ConcurrentQueue<Array> m_Queue = new ConcurrentQueue<Array>();
    
      public Example(int intervalMilliseconds)
      {
        var thread = new Thread(
          () =>
          {
            while (true)
            {
              Array array;
              while (m_Queue.TryDequeue(out array))
              {
                // Process the array here.
              }
              Thread.Sleep(intervalMilliseconds);
            }
          });
        thread.IsBackground = true;
        thread.Start();
      }
    
      public void Enqueue(Array array)
      {
        m_Queue.Enqueue(array);
      }
    }
