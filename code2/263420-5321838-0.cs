    public static Expression<Func<TModel, T>> GenerateMemberExpression<TModel, T>(string propertyName)
    {
        var propertyInfo = typeof(TModel).GetProperty(propertyName);
    
        var entityParam = Expression.Parameter(typeof(TModel), "e"); // {e}
        Expression columnExpr = Expression.Property(entityParam, propertyInfo); // {e.fieldName}
    
        if (propertyInfo.PropertyType != typeof(T))
            columnExpr = Expression.Convert(columnExpr, typeof(T));
    
        return Expression.Lambda<Func<TModel, T>>(columnExpr, entityParam);
    }
