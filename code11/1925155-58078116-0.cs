    private static IEnumerable<string> SubStrings(string value, int length = 2) {
      if (string.IsNullOrEmpty(value))
        yield break;
      else if (length <= 0)
        yield break;
      for (int i = 0; i < value.Length; ++i) {
        StringBuilder sb = new StringBuilder(length);
        for (int j = 0; j < length; ++j)
          sb.Append(value[(i + j) % value.Length]);
        yield return sb.ToString();
      }
    }
