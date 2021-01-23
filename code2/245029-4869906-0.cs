    public static bool CountEquals<T>(this IEnumerable<T> items, int n)
    {
      var iCollection = items as System.Collections.ICollection;
      if (iCollection != null)
        return iCollection.Count == n;
      return items.Take(n + 1).Count() == n;
    }
