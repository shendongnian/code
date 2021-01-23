    Execute(object lockObject)
    {
        lock (lockObject)
        {
            while (!complete)
            {
                Monitor.Wait(lockObject);
                // logic to execute when signaled
            }
        }
    }
