    public static bool ContainsExactlyOneItem<T>(this IEnumerable<T> source)
    {
        using (IEnumerator<T> iterator = source.GetEnumeartor())
        {
            return iterator.MoveNext() && !iterator.MoveNext();
        }
    }
