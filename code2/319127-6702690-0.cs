    public void TestMethod()
    {
        //initialize
        List<int> list = new List<int>();
        list.Add(1);
        list.Add(2);
        // Test setup
        Assert.IsTrue(List.Count == 2);
        Assert.IsTrue(List[0] == 1);
        Assert.IsTrue(List[1] == 2);
        //do operation
        list.Add(3);
        Assert.IsTrue(List.Count == 3);
        Assert.IsTrue(List[0] == 1);
        Assert.IsTrue(List[1] == 2);
        Assert.IsTrue(List[2] == 3);
    }
