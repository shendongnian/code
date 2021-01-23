    public static Dictionary<int, string> GetSelectValuesDictionary(string inputString)
    {
      return Regex.Matches(inputString, @"(?<key>[0-9]+)\$*(?<value>[^$]+)")
        .Cast<Match>()
        .ToDictionary(
            m => int.Parse(m.Groups["key"].Value),
            m => m.Groups["value"].Value);
    }
