    [Test]
    public void MyTest()
    {
        var assertsToRun = TestContext.Properties["executeAsserts"].Split(",").Select(x => Convert.ToInt(x)).ToArray();
        if(assertsToRun.Contains(1)
            Assert.That(...);
        if(assertsToRun.Contains(2)
            Assert.That(...);
        if(assertsToRun.Contains(3)
            Assert.That(...);
    }
