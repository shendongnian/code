    public Func<MyAbstractClass<T>, Object> GetPropertyGetter(PropertyInfo property)
    {
        var parameter = Expression.Parameter(typeof(MyAbstractClass<T>), "i");
        var cast = Expression.TypeAs(parameter, property.DeclaringType);
        var getterBody = Expression.Property(cast, property);
        var exp = Expression.Lambda<Func<MyAbstractClass<T>, Object>>(
            getterBody, parameter);
        return exp.Compile();
    }
