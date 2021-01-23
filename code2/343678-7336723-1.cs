    public static void Scan(String str)
    {
      // This regex is pretty nasty, I would probably take more time to refine it.
      String patt = @"([A-Za-z]+)(\s+)(\d+)";
    
      foreach (Match match in Regex.Matches(str, patt, RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace))
      {
        String value = match.Value;
    
        Console.WriteLine(value);
      }
    }
