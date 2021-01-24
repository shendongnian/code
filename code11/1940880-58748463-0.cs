    Expression<Func<TEntity, TKey>> BuildSelectExpression()
    {
        // Find key property
        PropertyInfo keyProperty = typeof(TEntity).GetProperties()
            .Where(p => p.GetCustomAttribute<KeyAttribute>() != null)
            .Single();
        
        ParameterExpression parameter = Expression.Parameter(typeof(TEntity));
        MemberExpression result = Expression.Property(parameter, keyProperty);
        // UnaryExpression result = Expression.Convert(property1, typeof(TKey)); this is also redundant
        return Expression.Lambda<Func<TEntity, TKey>>(result, parameter);
    }
