    [TestMethod]
    public void AssertInCalledMethod() //this will pass
    {
        Assert.IsTrue(true);
        Blah();
    }
    
    public void Blah()
    {
        Assert.IsTrue(false);
    }
