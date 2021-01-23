    public static TEntity GetByID<TEntity>(this IEnumerable<TEntity> list, Func<TEntity,bool> selector) where TEntity : Identifiable
    {
       return list.SingleOrDefault(selector);
    }
    
    public static TEntity GetByID<TEntity>(this IQueryable<TEntity> list, Func<TEntity,bool> selector) where TEntity : Identifiable
    {
        return list.SingleOrDefault(selector);
    }
