    public static bool ContainsExactlyOneItem<T>(this IEnumerable<T> source)
    {
        using (IEnumerator<T> iterator = source.GetEnumeartor())
        {
            // Check we've got at least one item
            if (!iterator.MoveNext())
            {
                return false;
            }
            // Check we've got no more
            return !iterator.MoveNext();
        }
    }
