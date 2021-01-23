    public static void Scan(String str)
    {
      String digits = @"(\d+)";
    
      foreach (Match match in Regex.Matches(str, digits, RegexOptions.IgnoreCase | RegexOptions.IgnorePatternWhitespace))
      {
        String value = match.Value;
    
        Console.WriteLine(value);
      }
    }
