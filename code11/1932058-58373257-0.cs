public static class Extension
{
    public static IEnumerable<T> WhereNotNull<T>(this IEnumerable<T?> o) where T:class
    {
        return o.Where(x => x != null)!;
    }
}
