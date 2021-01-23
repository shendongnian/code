    public static void ConvertInPlace<T>(this IList<T> source, Func<T, T> projection)
    {
        for (int i = 0; i < source.Count; i++)
        {
            source[i] = projection(source[i]);
        }
    }
