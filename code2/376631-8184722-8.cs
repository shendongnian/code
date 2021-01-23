    public static class EnumerableEx {
      public static IEnumerable<T> Append<T>(this IEnumerable<T> source, T item) {
        return source.Concat(new T[] { item });
      }
    }
