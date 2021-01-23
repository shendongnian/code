    bool forceFullCollection = false;
    Int64 valTotalMemoryBefore = System.GC.GetTotalMemory(forceFullCollection);
    //call String.Substring
    Int64 valTotalMemoryAfter = System.GC.GetTotalMemory(forceFullCollection);
    Int64 valDifferenceMemorySize = valTotalMemoryAfter - valTotalMemoryBefore;
