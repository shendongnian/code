    [TestMethod]
    public void YourTestName()
    {
        Assert.IsTrue(2.Between(0, 5));
        Assert.IsFalse("a".Between("b", "d"));
    }
