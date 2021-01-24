    private static readonly object[] _data =
        {
            new object[] { new List<string> { "3", "+", "3" }, "6" },
            new object[] { new List<string> { "5", "+", "10" }, "15" }
        };
    [Test, TestCaseSource(nameof(_data))]
    public void Test(List<string> calculation, string expectedResult)
    {
        var result = SolveCalculation(calculation);
        Assert.That(result, Is.EqualTo(expectedResult));
    }
