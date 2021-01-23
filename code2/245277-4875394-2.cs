    [Test]
    public void large_object_heap_objects_are_reported_as_max_generation()
    {
        int[] bling = new int[85000 / 4];
        int maxGen = GC.MaxGeneration;
        int objectGen = GC.GetGeneration(bling);
        Assert.AreEqual(maxGen, objectGen, "LOH object is at max generation.");
    }
