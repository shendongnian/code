    public IEnumerable SumTestData() {
        return new List<TestCaseData> {
            new TestCaseData( 1,  1).Returns(2),
            new TestCaseData(-1,  1).Returns(0),
            new TestCaseData( 1,  2).Returns(3),
            new TestCaseData( 1, -1).Returns(0)
        };
    }
    [Test]
    [TestCaseSource("SumTestData")]
    public int SumTest(int first, int second)
    {
        return Sum(first, second);
    }
