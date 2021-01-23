    [TestMethod]
    public void ParsedResultsForIllegalDataShouldContainWarnings()
    {
        var parsedResult = new MyParser.Parse<Foo>( dataThatContainsErrors );
        
        Assert.IsNotNull(parsedResult);
        Assert.IsNotNull(parsedResult.Result);
        Assert.AreEqual(1, parsedResult.Warnings.Count);
    }
