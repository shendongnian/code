    while (true)
    {
        foreach (Object lockObj in lockObjects) 
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
                }
            }
        }
    }
