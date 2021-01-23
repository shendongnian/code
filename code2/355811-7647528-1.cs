    [Test]
    public void Test()
    {
        var item = new ClassUnderTest();
        int initialCount = item.CountDic();
    
        item.AddSth();
    
        int finalCount = item.CountDic();
    
        Assert.That(finalCount == initialCount + 1);
    }
