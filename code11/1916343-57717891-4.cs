    [Theory]
    [MemberData(nameof(DataGeneratorMethod))]
    public void MemberDataTest(string first, string second)
    {
        Assert.Equal("a", first);
        Assert.Equal("b", second);
    }
    public static IEnumerable<object[]> DataGeneratorMethod()
    {
        var result = new List<object[]>();   // each item of this list will cause a call to your test method
        result.Add(new object[] {"a", "b"}); // "a" and "b" are parameters for one test method call
        return result;
        // or 
        // yield return new object[] {"a", "b"};
    }
