    private static Type GetCoreType(Type type)
    {
        if (type.IsGenericType &&
            type.GetGenericTypeDefinition() == typeof(Nullable<>))
            return Nullable.GetUnderlyingType(type);
        else
            return type;
    }
