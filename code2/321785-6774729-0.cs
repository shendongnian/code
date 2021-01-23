    [Test]
    public void Test()
    {
        int x = Builder<int>.CreateNew().Build();
        int y = Builder<int>.CreateNew().Build();
    
        Assert.AreEqual(x + y, ObjectUnderTest.Add(x, y));
    }
