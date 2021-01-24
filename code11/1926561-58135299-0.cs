[Test]
public void TestOne()
{
    var test = new SemParserLibrary.SemSummaryInfo();
    double[] testValues = new double[] {0, 0.0, 0.1, 1.1, 10, 010, 150, 299, 299.9, 300, 300.0};
    
    Assert.Multiple(() =>
    {
        foreach (int i in testValues)
        {
            test.Rate.LogRate = i;
            var testFile = new ParserLibrary.SummaryInfo(test);
            var parsedRecord = ParserLibrary.FileManager.ParseRecord(testFile);
            Assert.AreEqual(parsedRecord.Summary.Data.Rate.LogRate, i, "The de-serialised Rate {0} does not match the input value of {1}", parsedRecord.Summary.Data.Rate.LogRate, i);
        }
    });
}
