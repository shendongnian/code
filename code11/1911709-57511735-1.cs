    public static TProperty NewIfNull<TObj, TProperty>(this TObj obj, Expression<Func<TObj, TProperty>> selector)
    {
        if (!(selector.Body is MemberExpression memberExpression)
            || !(memberExpression.Member is PropertyInfo propertyInfo))
        {
            throw new ArgumentException("Expected a lambda in the form x => x.Property", nameof(selector));
        }
        var property = (TProperty)propertyInfo.GetValue(obj);
        if (property == null)
        {
            // We already know that typeof(TProperty).IsClass is true - if it
            // wasn't, then 'property' could not have been null above.
            property = (TProperty)Activator.CreateInstance(typeof(TProperty));
            propertyInfo.SetValue(obj, property);
        }
        return property;
    }
