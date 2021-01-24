    private static LambdaExpression CreatePropertyGetterExpression(Type entityType,
                                                                   string propertyName)
    {
        PropertyInfo property = entityType.GetProperty(propertyName);
        var parameter = Expression.Parameter(entityType, "e");
        var body = Expression.MakeMemberAccess(parameter, property);
        return Expression.Lambda(body, parameter);
    }
