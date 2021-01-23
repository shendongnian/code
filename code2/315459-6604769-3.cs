    public class Example
    {
      private BlockingCollection<object> queue = new BlockingCollection<object>(new NoDuplicatesConcurrentQueue<object>());
      public Example()
      {
        new Thread(Consume).Start();
      }
      public void Produce(object item)
      {
        bool unique = queue.TryAdd(item);
      }
      private void Consume()
      {
        while (true)
        {
          object item = queue.Take();
        }
      }
    }
