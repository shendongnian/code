    public static void DumpProcessesCpu(string machineName)
    {
        List<PerformanceCounter> counters = new List<PerformanceCounter>();
        foreach (Process process in Process.GetProcesses(machineName))
        {
            PerformanceCounter processorTimeCounter = new PerformanceCounter(
                "Process",
                "% Processor Time",
                process.ProcessName,
                machineName);
            processorTimeCounter.NextValue();
            counters.Add(processorTimeCounter);
        }
        Thread.Sleep(1000); // 1 second wait, needed to get a sample
        foreach (PerformanceCounter processorTimeCounter in counters)
        {
            Console.WriteLine("Process:{0} CPU% {1}",
                processorTimeCounter.InstanceName,
                processorTimeCounter.NextValue());
        }
    }
