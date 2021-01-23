    public IEnumerable SumTestData() {
        var cases = new List<TestCaseData>();
        cases.Add(new TestCaseData(1, 1, 2));
        cases.Add(new TestCaseData(-1, 1, 0));
        cases.Add(new TestCaseData(1, 2, 3));
        cases.Add(new TestCaseData(1, -1, 0));
        return cases
    }
    [Test]
    [TestCaseSource("SumTestData")]
    public void SumTest(int first, int second, int expected) {
    }
