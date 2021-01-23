    ConstantExpression searchTextExp = Expression.Constant(string.Format("{0}%", searchText));
    ParameterExpression parameterExp =    Expression.Parameter(typeof(ViewWageConstInEntity), "WageConstIn");
    MemberExpression propertyExp = Expression.Property(parameterExp, searchField);
    MethodCallExpression likeExpr = null;
    if (propertyExp.Type == typeof(decimal))
    {
        likeExpr = LinqExpression.Call(
            typeof(Functions).GetMethod("Like", new[] { typeof(decimal), typeof(string) }),
                        propertyExp, searchTextExp);
    }
    else if (propertyExp.Type == typeof(string))
    {
        likeExpr = Expression.Call(
            typeof(Functions).GetMethod("Like", new[] { typeof(string), typeof(string) }),
                        propertyExp, searchTextExp);
    }
