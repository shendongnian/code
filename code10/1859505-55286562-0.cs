    public int GetCPUUsage()
    {
        var cpuCounter = new PerformanceCounter("Processor", "% Processor Time", "_Total", Environment.MachineName);
        cpuCounter.NextValue();
        System.Threading.Thread.Sleep(1000);
        return (int)cpuCounter.NextValue();
    }
