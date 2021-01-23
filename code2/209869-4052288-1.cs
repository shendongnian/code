    [TestMethod]
    public void Test1()
    {
        count = 0;
        IEnumerable<MyClass> yieldResult = GetYieldResult(1).ToList();
        var firstGet = yieldResult.First();
        var secondGet = yieldResult.First();
        Assert.AreEqual(1, firstGet.Id);
        Assert.AreEqual(1, secondGet.Id);
        Assert.AreEqual(2, count);//calling "First()" 2 times, yieldResult is created 1 time
        Assert.AreSame(firstGet, secondGet);
    }
