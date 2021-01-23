    var testClasses = new[] { "a", "b", "c", "d" };
    foreach(var testClass in testClasses.Select(x => new TestClass()))
    {
        testClass.Property = "test";
    }
    foreach(var testClass in testClasses.Select(x => new TestClass()))
    {
        Assert.That(!string.IsNullOrEmpty(testClass.Property));
    }
