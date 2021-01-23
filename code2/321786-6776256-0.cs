    public class CustomThreadPool
    {
      private BlockingCollection<Action> m_WorkItems = new BlockingCollection<Action>();
    
      public CustomThreadPool(int numberOfThreads)
      {
        for (int i = 0; i < numberOfThreads; i++)
        {
          var thread = new Thread(
            () =>
            {
              while (true)
              {
                Action action = m_WorkItems.Take();
                action();
              }
            });
          thread.IsBackground = true;
          thread.Start();
        }
      }
    
      public void QueueUserWorkItem(Action action)
      {
        m_WorkItems.Add(action);
      }
    }
