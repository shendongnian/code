    public static IEnumerable<T> Append<T>(this IEnumerable<T> enumerable, T item)
    {
     return enumerable.Concat(new[] { item });
    }
    public static IEnumerable<T> AppendIf<T>(this IEnumerable<T> enumerable, T item, Func<bool> predicate)
    {
     return predicate() ? enumerable.Append(item) : enumerable;
    }
