    private static string GreedyTranslit(string value) {
      if (string.IsNullOrEmpty(value))
        return value;
      StringBuilder result = new StringBuilder(value.Length); 
      int longest = translit.Keys.Max(key => key.Length);
      for (int i = 0; i < value.Length; ) {
        var subs = translit
          .Where(pair => value
             .Substring(i)
             .StartsWith(pair.Key, StringComparison.OrdinalIgnoreCase))
          .OrderByDescending(pair => pair.Key.Length)
          .FirstOrDefault();
        if (subs.Key == null) {
          result.Append(value[i]);
          i += 1;
        }
        else {
          result.Append( char.IsUpper(value[i]) 
            ? CultureInfo.InvariantCulture.TextInfo.ToTitleCase(subs.Value) 
            : subs.Value);
          i += subs.Key.Length;
        }
      }
      return result.ToString();
    }
