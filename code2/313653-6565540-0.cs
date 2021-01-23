    void ExecutedByMultipleThreads(ConcurrentQueue<object> queue)
    {
      object value;
      if (!queue.IsEmpty)
      {
        queue.TryDequeue(out value);
        Console.WriteLine(value.GetHashCode());
      }
    }
