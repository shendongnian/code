    public static class EnumerableExtensions {
    
      public static IEnumerable<T> EmptyIfNull<T>(this IEnumerable<T> collection) {
        return collection ?? Enumerable.Empty<T>();
      }
    
    }
