    private static void DoStuff(int i)
    {
        lock (stuffSyncRoot)
        {
            if (!isCoolingDown)
            {
                lock (stuffSyncRoot)
                {
                    isCoolingDown = true;
                    new TaskFactory().StartNewDelayed(500, () => isCoolingDown = false);
    
                    Console.WriteLine("Handling {0} at {1}ms", i, sw.ElapsedMilliseconds);
                }
            }
        }
    }
