    public sealed class BlockingList<T>
    {
      private readonly List<T> data;
      private readonly int maxCount;
      public BlockingList(int maxCount)
      {
        this.data = new List<T>();
        this.maxCount = maxCount;
      }
      public void Add(T item)
      {
        lock (data)
        {
          // Wait until the collection is not full.
          while (data.Count == maxCount)
            Monitor.Wait(data);
          // Add our item.
          data.Add(item);
          // If the collection is no longer empty, signal waiting threads.
          if (data.Count == 1)
            Monitor.PulseAll(data);
        }
      }
      public T Remove()
      {
        lock (data)
        {
          // Wait until the collection is not empty.
          while (data.Count == 0)
            Monitor.Wait(data);
          // Remove our item.
          T ret = data.RemoveAt(data.Count - 1);
          // If the collection is no longer full, signal waiting threads.
          if (data.Count == maxCount - 1)
            Monitor.PulseAll(data);
        }
      }
    }
