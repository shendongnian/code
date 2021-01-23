    private void TestData(IEnumerable what ) { ... your test method ... }
    [TestMethod]
    public void TestDataInMemory() { List<T> mylist = ...; this.TestData(mylist); }
    [TestMethod]
    [DataSource(
        "Microsoft.VisualStudio.TestTools.DataSource.CSV", 
        "Data.csv", 
        "Data#csv", 
        DataAccessMethod.Sequential)]
    public void TestData() { this.TestData(testContextInstance ...) }
