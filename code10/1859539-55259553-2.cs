    [Theory]
    [InlineData("input_1", "pattern")]
    [InlineData("input_2", "pattern")]
    [InlineData("input_x", "pattern")]
    public void ShouldMatch(string input, string pattern)
    {
      try
      {
        var isMatch = Regex.IsMatch(input, pattern);
        Assert.True(isMatch);
      }
      catch (ArgumentException)
      {
        Assert.True(false);
      }
    }
