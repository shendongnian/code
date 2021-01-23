    public static IEnumerable<IEnumerable<T>> DoIt<T>(this IEnumerable<T> that) {
      using (var e = that.GetEnumerator()) {
        if (!e.MoveNext()) {
          yield break;
        }
    
        bool hasMore;
        do {
          var item = e.Current;
          var list = new List<T>();
          list.Add(item);
          
          hasMore = e.MoveNext();
          while (hasMore && item.Equals(e.Current)) {
            list.Add(e.Current);
            hasMore = e.MoveNext();
          }
          yield return list;
        } while (hasMore);
    }
