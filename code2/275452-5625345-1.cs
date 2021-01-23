    public static IEnumerable<string> SplitAndKeepSeparators(this string source, string[] separators) {
      var builder = new Text.StringBuilder();
      foreach (var cur in source) {
        builder.Append(cur);
        if (separators.Contains(cur)) {
          yield return builder.ToString();
          builder.Length = 0;
        }
      }
      if (builder.Length > 0) {
        yield return builder.ToString();
      }
    }
