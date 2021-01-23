    static void ExecuteWorker(object lockObject)
    {
        lock (lockObject)
        {
            // Signal to thread creator that the thread is running.
            Montior.Pulse(lockObject);
            // Keep running while we have not been marked to shut down
            while (!complete)
            {
                Monitor.Wait(lockObject);
                // logic to execute when signaled (value == 0)
            }
        }
    }
