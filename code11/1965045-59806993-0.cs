    [DataTestMethod]
    [DynamicData(nameof(TestDataMethod), DynamicDataSourceType.Method)]
    public void TestMethod(int[,] expected)
    {
          // some code...
    }
    
    static IEnumerable<object[]> TestDataMethod() {
        return new int[,] { {0, 0}, {1, 1} };
    }
