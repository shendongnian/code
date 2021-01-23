    public static IQueryable<T> IncludeMultiple<T>(this IQueryable<T> query, params string[] includes)
        where T : class
    {
        if (includes != null)
        {
            var objectQuery = query as ObjectQuery;
    
            if (objectQuery == null)
            {
                throw new InvalidOperationException("...");
            }
    
            objectQuery = includes.Aggregate(objectQuery, 
                      (current, include) => current.Include(include));
        }
    
        return objectQuery;
    }
