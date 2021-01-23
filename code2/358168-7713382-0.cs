    public static IQueryable<T> IsActive<T>(this IQueryable<T> source, bool isActive)
        where T : ICanBeActive
    {
        // Lambda converted to an expression tree
        return source.Where(x => x.IsActive == isActive);
    }
    
    public static IEnumerable<T> IsActive<T>(this IEnumerable<T> source,
        bool isActive) where T : ICanBeActive
    {
        // Lambda converted to a delegate
        return source.Where(x => x.IsActive == isActive);
    }
