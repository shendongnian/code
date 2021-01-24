    public static object GetDefaultValue<T, K>(this T obj, Expression<Func<T, K>> exp)
    {
        var propertyName = ((MemberExpression)exp.Body).Member.Name;
        return TypeDescriptor.GetProperties(obj)[propertyName]
            .Attributes.OfType<DefaultValueAttribute>()
            .FirstOrDefault()?.Value ?? default(K);
    }
