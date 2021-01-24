    [DataTestMethod]
    [DynamicData(nameof(TestDataMethod), DynamicDataSourceType.Method)]
    public void TestCOMPortSorting(string[] unorderedPorts, string[] expectedOrderedPorts) {
        //...
    }
    static IEnumerable<object[]> TestDataMethod() {
        return new[] {
            new []{ new[] { "COM3", "COM1", "COM2" }, new[] { "COM1", "COM2", "COM3" } } //a data row
        };
    }
