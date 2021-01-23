    PerformanceCounter cpuCounter = new PerformanceCounter();
    cpuCounter.CategoryName = "Processor";
    cpuCounter.CounterName = "% Processor Time";
    cpuCounter.InstanceName = "_Total";
    double cpuUsage = Convert.ToDouble(cpuCounter.NextValue());
