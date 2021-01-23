    public static void LogProcessMemoryUsage()
    {
        try
        {
            PerformanceCounterCategory cat = new PerformanceCounterCategory("Process");
    
            string[] instanceNames = cat.GetInstanceNames();
    
            foreach (string name in instanceNames)
            {
                try
                {
                    PerformanceCounter counter = new PerformanceCounter("Process", "Private Bytes", name, true);
                    PerformanceCounter setCounter = new PerformanceCounter("Process", "Working Set", name, true);
                    PerformanceCounter poolNPCounter = new PerformanceCounter("Process", "Pool Nonpaged Bytes", name, true);
    
                    log.InfoFormat("Memory usage for process [{0}]", name);
                    log.InfoFormat("\tMem Usage:       {0} KB", (setCounter.NextValue()/1024f));
                    log.InfoFormat("\tVM Size:         {0} KB", (counter.NextValue()/1024f));
                    log.InfoFormat("\tNon-Paged Pool:  {0} KB", (poolNPCounter.NextValue() / 1024f));
                }
                catch (Exception ex)
                {
                    log.InfoFormat("Could not read memory stats for process {0}", name);
                }
            }
        }
        catch(Exception ex2)
        {
            log.Info("Cannot retrieve memory performance counter statistics");
        }
    }
