    [Theory]
    [InlineData("a", "b")]
    public void InlineDataTest(string first, string second)
    {
        Assert.Equal("a", first);
        Assert.Equal("b", second);
    }
