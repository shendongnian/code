    public static EnumerableExtensions
    {
      public static IEnumerable<T> EmptyIfNull<T>(this IEnumerable<T> enumerable)
      {
        return enumerable ?? Enumerable.Empty<T>();
      }
    }
