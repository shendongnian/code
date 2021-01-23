    int tries = 0;
    while (tries++ < 2)
    {
      try 
      {
        . . some large allocation . .
        return;
      }
      catch (System.OutOfMemoryException)
      {
    	System.Runtime.GCSettings.LargeObjectHeapCompactionMode = System.Runtime.GCLargeObjectHeapCompactionMode.CompactOnce;
    	GC.Collect();
      }
    }
