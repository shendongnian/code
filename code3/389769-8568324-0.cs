      public static IEnumerable<T> EmptyIfNull<T>(this IEnumerable<T> list)
      {
        return list ?? IEnumerable<T>.Empty();
      }
      foreach(var x in xs.EmptyIfNull())
      {
        ...
      }
