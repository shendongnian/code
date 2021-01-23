    .
    .
    dsGrid.InitialCapacity = count;
    if (count > 10625)
    {
    	System.Runtime.GCSettings.LargeObjectHeapCompactionMode =
    		System.Runtime.GCLargeObjectHeapCompactionMode.CompactOnce;
    }
    daGrid.Fill(dsGrid, "Query");
    .
    .
