    bool forceFullCollection = true;
    Int64 valTotalMemoryBefore = System.GC.GetTotalMemory(forceFullCollection);
    //call here your bulk of Dictionary operations
    Int64 valTotalMemoryAfter = System.GC.GetTotalMemory(forceFullCollection);
    Int64 valDifferenceMemorySize = valTotalMemoryAfter - valTotalMemoryBefore;
