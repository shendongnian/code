    ulong total = My.Computer.Info.TotalPhysicalMemory;
    ulong available = My.Computer.Info.AvailablePhysicalMemory;
    int pctAvailable = (int)Math.Ceiling((double)available * 100 / total);
    int pctUsed = (int)Math.Ceiling((double)(total - available) * 100 / total);
    
