    public static void SetToNull<TEntity, TProperty>(this TEntity entity, Expression<Func<TEntity, TProperty>> navigationProperty, DbContext context = null)
        where TEntity : class
        where TProperty : class
    {
        var pi = GetPropertyInfo(entity, navigationProperty);
                
        if (context != null)
        {
            //If DB Context is supplied, use Entry/Reference method to null out current value
            context.Entry(entity).Reference(navigationProperty).CurrentValue = null;
        }
        else
        {
            //If no DB Context, then lazy load first
            var prevValue = (TProperty)pi.GetValue(entity);
        }
    
        pi.SetValue(entity, null);
    }
    
    static PropertyInfo GetPropertyInfo<TSource, TProperty>(    TSource source,    Expression<Func<TSource, TProperty>> propertyLambda)
    {
        Type type = typeof(TSource);
    
        MemberExpression member = propertyLambda.Body as MemberExpression;
        if (member == null)
            throw new ArgumentException(string.Format(
                "Expression '{0}' refers to a method, not a property.",
                propertyLambda.ToString()));
    
        PropertyInfo propInfo = member.Member as PropertyInfo;
        if (propInfo == null)
            throw new ArgumentException(string.Format(
                "Expression '{0}' refers to a field, not a property.",
                propertyLambda.ToString()));
    
        if (type != propInfo.ReflectedType &&
            !type.IsSubclassOf(propInfo.ReflectedType))
            throw new ArgumentException(string.Format(
                "Expression '{0}' refers to a property that is not from type {1}.",
                propertyLambda.ToString(),
                type));
    
        return propInfo;
    }
