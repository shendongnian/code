    public static List<int> FormObjectIndexExtractor(IEnumerable<string> values, string prefix, string suffix)
    {
      int? TryParseItem(string val)
      {
        if (val.Length <= prefix.Length + suffix.Length || !val.StartsWith(prefix) || !val.EndsWith(suffix))
          return null;
        var subStr = val.Substring(prefix.Length, val.Length - prefix.Length - suffix.Length);
        if (int.TryParse(subStr, out var number))
          return number;
        return null;
      }
      return values.Select(TryParseItem).Where(v => v.HasValue).Select(v => v.Value).ToList();
    }
