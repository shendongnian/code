    public class NoDuplicatesConcurrentQueue<T> : IProducerConsumerCollection<T>
    {
      // TODO: You will need to fully implement IProducerConsumerCollection.
      private Queue<T> queue = new Queue<T>();
    
      public bool TryAdd(T item)
      {
        lock (queue)
        {
          if (!queue.Contains(item))
          {
            queue.Enqueue(item);
            return true;
          }
          return false;
        }
      }
    
      public bool TryTake(out T item)
      {
        lock (queue)
        {
          item = null;
          if (queue.Count > 0)
          {
            item = queue.Dequeue();
          }
          return item != null;
        }
      }
    }
