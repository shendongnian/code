    /* 
    *  string – handle name,
    *  IHandle – the handle,
    *  int – hit count,
    */
    ConcurrentDictionary<string, (IHandle, int)> handles = new ConcurrentDictionary<string, (IHandle, int)>();
    
    void FreeResources()
    {
      if (handles.Count == 0)
      {
        return;
      }
    
      var performance = new System.Diagnostics.PerformanceCounter("Memory", "Available MBytes");
    
      while (performance.NextValue() <= YOUR_TRESHHOLD)
      {
        int maxIndex = (int)Math.Ceiling(handles.Count / 2.0d);
        KeyValuePair<string, (IHandle, int)> candidate = handles.First();
        
        for (int index = 1; index < maxIndex; index++)
        {
          KeyValuePair<string, (IHandle, int)> item = handles.ElementAt(index);
    
          if(item.Value.Item2 < candidate.Value.Item2)
          {
            candidate = item;
          }          
        }
    
        candidate.Value.Item1.Dispose();
        handles.TryRemove(candidate.Key, out _);
      }
    }
