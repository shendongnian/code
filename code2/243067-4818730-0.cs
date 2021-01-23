    public void CheckAsserts(string value)
    {
        Assert.IsNotNull(value);
    }
    
    [TestCase("yes!")]
    public void MyTest(string value)
    {
        CheckAsserts(value);
    }
