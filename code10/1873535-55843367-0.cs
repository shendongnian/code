    public static bool HasNullProperties(this MyClass x)
    {
        return x.Name == null
            && x.Location == null
            && x.OrderSize == null
            ...;
    }
    public static IEnumerable<MyClass> WhereHasNullProperties(this IEnumerable<MyClass> source)
    {
        return source.Where(item => item.HasNullProperties();
    }
