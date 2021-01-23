    public static string GetPropertyName<TSource, TProperty>(this Expression<Func<TSource, TProperty>> expression) {
        Contract.Requires<ArgumentNullException>(expression != null);
        Contract.Ensures(Contract.Result<string>() != null);
        PropertyInfo propertyInfo = GetPropertyInfo(expression);
        return propertyInfo.Name;
    }
    public static PropertyInfo GetPropertyInfo<TSource, TProperty>(this Expression<Func<TSource, TProperty>> expression) {
        Contract.Requires<ArgumentNullException>(expression != null);
        Contract.Ensures(Contract.Result<PropertyInfo>() != null);
        var memberExpression = expression.Body as MemberExpression;
        Guard.Against<ArgumentException>(memberExpression == null, "Expression does not represent a member expression.");
        var propertyInfo = memberExpression.Member as PropertyInfo;
        Guard.Against<ArgumentException>(propertyInfo == null, "Expression does not represent a property expression.");
        Type type = typeof(TSource);
        Guard.Against<ArgumentException>(type != propertyInfo.ReflectedType && type.IsSubclassOf(propertyInfo.ReflectedType));
        return propertyInfo;
    }
