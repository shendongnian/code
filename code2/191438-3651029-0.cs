    public static bool One<T>(this IEnumerable<T> enumerable)
    {
      var enumerator = enumerable.GetEnumerator();
      return enumerator.MoveNext() && !enumerator.MoveNext();
    }
    
    public static bool Two<T>(this IEnumerable<T> enumerable)
    {
      var enumerator = enumerable.GetEnumerator();
      return enumerator.MoveNext() && enumerator.MoveNext() && !enumerator.MoveNext();
    }
    
    public static bool MoreThanOne<T>(this IEnumerable<T> enumerable)
    {
      return enumerable.Skip(1).Any();
    }
    
    public static bool AtLeast<T>(this IEnumerable<T> enumerable, int count)
    {
      var enumerator = enumerable.GetEnumerator();
        for (var i = 0; i < count; i++)
          if (!enumerator.MoveNext())
            return false;
      return true;
    }
    
    public static IEnumerable<T> ToEnumerable<T>(this T t, params T[] ts)
    {
      return new[] { t }.Concat(ts);
    }
    
    public static bool AnyAtAll<T>(this IEnumerable<T> enumerable)
    {
      return enumerable != null && enumerable.Any();
    }
