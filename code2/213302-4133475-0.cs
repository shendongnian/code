    static class StringExtensions {
      public static IEnumerable<String> SplitInParts(this String s, Int32 partLength) {
        if (s == null)
          throw new ArgumentNullException("s");
        for (var i = 0; i < s.Length; i += partLength)
          yield return s.Substring(i, Math.Min(partLength, s.Length - i));
      }
    }
