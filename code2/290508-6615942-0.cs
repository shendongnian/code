    static Expression<Func<T, bool>> CreateAnyExpression<T, T2>(string propertyPath, 
                                        Expression<Func<T2, bool>> matchExpression)
    {
        var type = typeof(T);
        var parameterExpression = Expression.Parameter(type, "s");
        var propertyNames = propertyPath.Split('.');
        Expression propBase = parameterExpression;
        foreach(var propertyName in propertyNames)
        {
            PropertyInfo property = type.GetProperty(propertyName);
            propBase = Expression.Property(propBase, property);
            type = propBase.Type;
        }
        var itemType = type.GetGenericArguments()[0];
        // .Any(...) is better than .Count(...) > 0
        var anyMethod = typeof(Enumerable).GetMethods()
            .Single(m => m.Name == "Any" && m.GetParameters().Length == 2)
            .MakeGenericMethod(itemType);
        var callToAny = Expression.Call(anyMethod, propBase, matchExpression);
        return Expression.Lambda<Func<T, bool>>(callToAny, parameterExpression);
    }
