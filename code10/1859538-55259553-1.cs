    [Fact]
    public void ShouldMatch()
    {
      try
      {
        var isMatch = Regex.IsMatch("your_input", "your_pattern");
        Assert.True(isMatch);
      }
      catch (ArgumentException)
      {
        Assert.True(false);
      }
    }
