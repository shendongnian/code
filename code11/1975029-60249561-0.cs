    private void TestMemory(){
        long before = GC.GetTotalMemory(true);
        // Allocation code
        long after = GC.GetTotalMemory(true);
        double diff = after – before;
        Console.WriteLine(“Per object: “ + diff / size);
        // Stop the GC from messing up our measurements
        GC.KeepAlive(array);
    }
