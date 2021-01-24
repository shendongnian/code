    [TestCase(0)]
    [TestCase(0.0)]
    [TestCase(0.1)]  // etc.
    public void TestOne(int i)
    {
        var test = new SemParserLibrary.SemSummaryInfo();
        test.Rate.LogRate = i;
        var testFile = new ParserLibrary.SummaryInfo(test);
        var parsedRecord = ParserLibrary.FileManager.ParseRecord(testFile);
        Assert.AreEqual(parsedRecord.Summary.Data.Rate.LogRate, i, "The de-serialised Rate {0} does not match the input value of {1}", parsedRecord.Summary.Data.Rate.LogRate, i);
    }
