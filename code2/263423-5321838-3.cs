    public static Expression<Func<TModel, T>> GenerateMemberExpression<TModel, T>
       (string propertyName)
    {
        var propertyInfo = typeof(TModel).GetProperty(propertyName);
    
        var entityParam = Expression.Parameter(typeof(TModel), "e"); 
        Expression columnExpr = Expression.Property(entityParam, propertyInfo);
    
        if (propertyInfo.PropertyType != typeof(T))
            columnExpr = Expression.Convert(columnExpr, typeof(T));
    
        return Expression.Lambda<Func<TModel, T>>(columnExpr, entityParam);
    }
