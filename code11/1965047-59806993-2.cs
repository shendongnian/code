    [DataTestMethod]
    [DynamicData(nameof(TestDataMethod), DynamicDataSourceType.Method)]
    public void TestMethod1(int[,] expected)
    {
        // some code...
        var b = expected;
    }
    static IEnumerable<object[]> TestDataMethod()
    {
        return new[] { new[] { new int[,] { { 0, 0 }, { 1, 1 } } } };
    }
