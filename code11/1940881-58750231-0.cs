    static List<TKey> GetMatchingKeys<TEntity, TKey>(DbSet<TEntity> dbSet, List<TKey> keysToFind)
        where TEntity : class, IEntityWithKey
    {
        PropertyInfo keyProperty = typeof(TEntity).GetProperties().Single(x => x.GetCustomAttribute<KeyAttribute>() != null);
        return dbSet.Where(BuildWhereExpression()).Select(BuildSelectExpression()).ToList();
        Expression<Func<TEntity, bool>> BuildWhereExpression()
        {
            ParameterExpression entity = Expression.Parameter(typeof(TEntity));
            MethodInfo containsMethod = typeof(List<TKey>).GetMethod("Contains");
            ConstantExpression keys = Expression.Constant(keysToFind);
            MemberExpression property = Expression.Property(entity, keyProperty);
            MethodCallExpression body = Expression.Call(keys, containsMethod, property);
            return Expression.Lambda<Func<TEntity, bool>>(body, entity);
        }
        Expression<Func<TEntity, TKey>> BuildSelectExpression()
        {
            ParameterExpression entity = Expression.Parameter(typeof(TEntity));
            MemberExpression body = Expression.Property(entity, keyProperty);
            return Expression.Lambda<Func<TEntity, TKey>>(body, entity);
        }
    }
