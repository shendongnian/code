    public IEnumerable<TestCaseData> ProvideTestCases1()
    {
        return ProvideTestCases("Prefix1.");
    }
    
    public IEnumerable<TestCaseData> ProvideTestCases2()
    {
        return ProvideTestCases("Prefix2.");
    }
    
    private IEnumerable<TestCaseData> ProvideTestCases(string prefix)
    {
        yield return new TestCaseData(...).SetName(prefix + "Test1");
    }
