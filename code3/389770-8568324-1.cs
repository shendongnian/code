      public static IEnumerable<T> EmptyIfNull<T>(this IEnumerable<T> list)
      {
        return list ?? Enumerable.Empty<T>();
      }
      foreach(var x in xs.EmptyIfNull())
      {
        ...
      }
