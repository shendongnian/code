    public static string ToDelimitedString<T>(this IEnumerable<T> lst, string separator = ", ")
    {
        return lst.ToDelimitedString(p => p, separator);
    }
    public static string ToDelimitedString<S, T>(this IEnumerable<S> lst, Func<S, T> selector, 
                                                 string separator = ", ")
    {
        return string.Join(separator, lst.Select(selector));
    }
