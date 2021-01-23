    public IEnumerable SumTestData() {
        return new List<TestCaseData> {
            new TestCaseData( 1,  1,  2),
            new TestCaseData(-1,  1,  0),
            new TestCaseData( 1,  2,  3),
            new TestCaseData( 1, -1,  0)
        };
    }
    [Test]
    [TestCaseSource("SumTestData")]
    public void SumTest(int first, int second, int expected) {
    }
