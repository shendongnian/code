    public static void ForEach<T>(this IEnumerable<T> collection, Action<T> lambda)
    {
        foreach(var element in collection)
            lambda(element);
    }
    public static string FormatWith(this string base, params object[] args)
    {
        return String.Format(base, args);
    }
