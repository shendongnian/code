    public static void AddOrUpdate<TEntity>(
    	this IDbSet<TEntity> set,
    	params TEntity[] entities
    )
    where TEntity : class
