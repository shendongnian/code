    public static Match Match(string input, string pattern)
    {
      return new Regex(pattern, RegexOptions.None, true).Match(input);
    }
    public static Match Match(string input, string pattern, RegexOptions options)
    {
      return new Regex(pattern, options, true).Match(input);
    }
