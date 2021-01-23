    public MetadataRetrievalNode[] Browse(string nodeId, int childStartIndex, int maxChildNodes, TimeSpan timeout)
    {
        bool terminate = false;
    
        Func<MetadataRetrievalNode[]> work = 
          () => 
          {
            // Do some work.
    
            Thread.MemoryBarrier(); // Ensure a fresh read of the terminate variable.
            if (terminate) throw new InvalidOperationException();
    
            // Do some work.
    
            Thread.MemoryBarrier(); // Ensure a fresh read of the terminate variable.
            if (terminate) throw new InvalidOperationException();
    
            // Return computed metadata...
          };
    
        IAsyncResult result = work.BeginInvoke(null, null);
        terminate = !result.AsyncWaitHandle.WaitOne(timeout);
        return work.EndInvoke(result); // This blocks until the delegate completes.
    }
