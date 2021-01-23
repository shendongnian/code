    // Sample with Queue instead of ConcurrentQueue
    private void TestInsertInt(int id, int value)
    {
        myInstance.InsertInt(id, value);
        FieldInfo field = myInstance.GetType().GetField("listOfQueues", BindingFlags.NonPublic | BindingFlags.Instance);
        List<Queue<int>> listOfQueues = field.GetValue(myInstance) as List<Queue<int>>;
        int lastInserted = listOfQueues[id].Last();
        Assert.AreEqual(lastInserted, value);
    }
