    public static IEnumerable<Type> WhereDefinedOn(this Type type, IEnumerable<Type> types)
    {
        if (!typeof(Attribute).IsAssignableFrom(type))
            throw new InvalidOperationException("Only attribute types are supported.");
        return types.Where(t => t.IsDefined(type));
    }
