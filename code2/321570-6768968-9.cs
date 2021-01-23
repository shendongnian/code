    List<object> notQueuedItems = new List<object>(lockObjects);
    
    while (notQueuedItems.Count > 0)
    {
        foreach (Object lockObj in notQueuedItems) 
        {
            if (Monitor.TryEnter(lockObj)
            {
                try
                {
                    // do another work (may take some time)
                }
                finally
                {
                    Monitor.Exit(lockObj);
                    notQueuedItems.Remove(lockObj);
                }
            }
        }
        if (notQueuedItems.Count > 0)
        {
            Thread.Sleep(100);//give it some time to breath here.
        }
    }
