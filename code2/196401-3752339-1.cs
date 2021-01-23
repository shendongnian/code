    var propertyinfo = typeof(T).GetProperty(sortExpressionStr);
    Type orderType = propertyinfo.PropertyType;
    var param = Expression.Parameter(typeof(T), "x");
    var sortExpression = Expression.Lambda(
            Expression.Convert(Expression.Property(param, sortExpressionStr),
                               orderType), 
            param));
