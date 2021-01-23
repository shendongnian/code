    public static IEnumerable SumTestData() {
        yield return new TestCaseData( 1,  1).Returns(2);
        yield return new TestCaseData(-1,  1).Returns(0);
        yield return new TestCaseData( 1,  2).Returns(3);
        yield return new TestCaseData( 1, -1).Returns(0);
    }
    [Test]
    [TestCaseSource("SumTestData")]
    public int SumTest(int first, int second)
    {
        return Sum(first, second);
    }
