    public class Example
    {
      private BlockingCollection<Action> queue = new BlockingCollection<Action>();
    
      public Example()
      {
        new Thread(
          () =>
          {
            while (true)
            {
              Action action = queue.Take();
              action();
            }
          }).Start();
      }
    
      public void ExecuteAsync(Action action)
      {
        queue.Add(action);
      }
    }
