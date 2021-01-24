    public static bool IsOrderedSubsetOf<T>(IEnumerable<T> list, 
                                            IEnumerable<T> subset, 
                                            IComparer<T> comparer = null) {
      if (null == comparer)
        comparer = Comparer<T>.Default;
      if (null == comparer)
        throw new ArgumentNullException(nameof(comparer), 
                                      $"No default comparer for {typeof(T).Name}");
      if (null == list || null == subset)
        return false;
      using (var enSubset = subset.GetEnumerator()) {
        using (var enList = list.GetEnumerator()) {
          while (enSubset.MoveNext()) {
            while (true) {
              if (!enList.MoveNext())
                return false;
              else if (comparer.Compare(enList.Current, enSubset.Current) == 0)
                break;
           }
          }
        }
      }
      return true;
    }
