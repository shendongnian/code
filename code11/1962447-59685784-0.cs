    public static IIncludableQueryable<TEntity, TProperty> Include<TEntity, TProperty>( 
          this IQueryable<TEntity> source,
          Expression<Func<TEntity, TProperty>> navigationPropertyPath)
          where TEntity : class
    {
           // Method body
    }
