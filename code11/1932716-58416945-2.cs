    private Delegate buildRequiredFieldCheckDelegate(Type type, PropertyInfo propertyInfo) {
        //Func<T, bool>
        var delegateType = typeof(Func<,>).MakeGenericType(type, typeof(bool));
        var prpertyDefaultValue = getDefaultValue(propertyInfo.PropertyType);
        // p => p.Property != default(typeof(TProperty))
        // p =>
        var parameter = Expression.Parameter(type, "p");
        // p => p.Property
        var property = Expression.Property(parameter, propertyInfo);
        // default(TProperty);
        var defaultValue = Expression.Constant(prpertyDefaultValue);
        // p => p.Property != default(TProperty)
        var body = Expression.NotEqual(property, defaultValue);
        // Func<T, bool> = T p => p.Property != default(TProperty)
        var lambda = Expression.Lambda(delegateType, body, parameter);
        return lambda.Compile();
    }
    private static object getDefaultValue(Type type) {
        return type.IsValueType ? Activator.CreateInstance(type) : null;
    }
