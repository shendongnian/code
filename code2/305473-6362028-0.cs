    public static List<int> ExtractInts(string input)
    {
       return Regex.Matches(input, @"\d+")
          .Cast<Match>()
          .Select(x => Convert.ToInt32(x.Value))
          .ToList();
    }
