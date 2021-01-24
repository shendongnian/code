    public static void Main(string[] args)
    {
      List<string> result = new List<string>();
      var testString = "Jo Ka \"Vid Whi\"";
      var regex = new Regex("\"[^\"]+\"");
      var matches = regex.Matches(testString);
      // Remove matched string inside quotes and trim possible spaces
      testString = regex.Replace(testString, "").Trim();
      // Add all strings sorrounded by quotes and trim quotes
      foreach (Match match in matches) result.Add(match.Value.Trim('"'));
      // Add rest of strings, which were separated by space
      result.AddRange(testString.Split(' ').Select(s => s.Trim()));
    }
