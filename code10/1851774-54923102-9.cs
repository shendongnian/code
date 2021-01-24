    ConcurrentQueue<(string, IHandle)> handles = new ConcurrentQueue<(string, IHandle)>();
    void CheckMemory_OptionallyReleaseOldHandles()
    {
      var performance = new System.Diagnostics.PerformanceCounter("Memory", "Available MBytes");
      while (performance.NextValue() <= YOUR_TRESHHOLD)
      {
        if (handles.TryDequeue(out ValueTuple<string, IHandle> value))
        {
          value.Item2.Dispose();
        }
      }
    }
