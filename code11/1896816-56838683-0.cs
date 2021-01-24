    [TestMethod]
    public void TheRightWay()
    {
        // this is what you want to check
        var implements =
            typeof(IDoesItImplementThis).IsAssignableFrom(typeof(MightInheritOrImplement));
        var inherits =
            typeof(DoesItInheritFromThis).IsAssignableFrom(typeof(MightInheritOrImplement));
        Assert.IsTrue(implements);
        Assert.IsTrue(inherits);
    }
