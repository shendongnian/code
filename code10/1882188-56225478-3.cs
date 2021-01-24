    [TestMethod]
    public void TestWhenConstructorFinishes()
    {
        var subject = new HasConstructorWithAsyncCall();
        Assert.IsFalse(subject.ConstructorHasFinished);
        Thread.Sleep(600);
        Assert.IsTrue(subject.ConstructorHasFinished);
    }
