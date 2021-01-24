    public static bool IsOrderedSubset<T>(IList<T> a, IList<T> b, IEqualityComparer<T> comparer)
    {
      //Quick checks
      if (a == null || b == null || b.Count == 0) return false;
      if (ReferenceEquals(a, b)) return true;
      if (b.Count > a.Count) return false;
      for (var aIndex = 0; aIndex < a.Count; aIndex++)
      {
        int bIndex;
        for (bIndex = 0; bIndex < b.Count && aIndex + bIndex < a.Count; bIndex++)
        {
          if (!comparer.Equals(a[aIndex + bIndex], b[bIndex]))
            break; //met a mismatch, so bIndex will be reset, and outer loop continues to find the next, first match.
        }
        if (bIndex == b.Count)
          return true; //Reached end of list b with all matched
      }
      return false;
    }
