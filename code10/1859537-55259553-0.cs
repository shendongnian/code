       try
      {
        var isMatch = Regex.IsMatch("input", "pattern");
        Assert.True(isMatch);
      }
      catch (ArgumentException)
      {
        Assert.True(false);
      }
