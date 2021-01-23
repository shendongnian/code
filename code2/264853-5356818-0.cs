        System.Diagnostics.PerformanceCounter cpuUsage = 
          new System.Diagnostics.PerformanceCounter();
        cpuUsage.CategoryName = "Processor"; 
        cpuUsage.CounterName = "% Processor Time";
        cpuUsage.InstanceName = "_Total";
        float f = cpuUsage.NextValue();
