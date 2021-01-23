    static IEnumerable<string> SplitInGroups (this string original, int size) {
      var p = 0;
      var l = original.Length;
      while (l - p > size) {
        yield return original.Substring (p, size);
        p += size;
      }
      yield return original.Substring (p);
    }
