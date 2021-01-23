    private volatile bool shouldStop = true;
    // T1:
    directoryChanged()
    {
      // StopReplicating
      shouldStop = true;
      workerReady.WaitOne(); // Wait for the worker to stop replicating.
      // StartReplicating
      shouldStop = false;
      replicationStarter.Set();
    }
    
    // T2:
    while (whatever)
    {
      replicationStarter.WaitOne();
      ... // prepare, throw some shouldStops so worker does not have to work too much.
      if (!shouldStop)
      {
        foreach (var file in files)
        {
          if (shouldStop) break;
          // Copy the file or whatever.
        }
      }
      workerReady.Set();
    }
