    public static IEnumerable<T> Interleave<T> (
        this IEnumerable<T> first, IEnumerable<T> second)
    {
      using (var enumerator1 = first.GetEnumerator())
      using (var enumerator2 = second.GetEnumerator())
      {
        bool firstHasMore;
        bool secondHasMore;
    
        while ((firstHasMore = enumerator1.MoveNext())
             | (secondHasMore = enumerator2.MoveNext()))
        {
          if (firstHasMore)
            yield return enumerator1.Current;
    
          if (secondHasMore)
            yield return enumerator2.Current;
        }
      }
    }
