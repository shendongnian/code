    [Test]
    public void GetVarUrlPasses()
    {
        var url = "http://www.chicagoshakes.com/main.taf?p=7,8";
        var attribute = new RegularExpressionAttribute(regex);
        Assert.IsTrue(regex.IsValid(url));
    }
