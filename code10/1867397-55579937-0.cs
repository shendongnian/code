    public static bool IsConstructableFrom(this Type type, Type genericTypeDefinition)
    {
        return type.IsConstructedGenericType &&
            (type.GetGenericTypeDefinition() == genericTypeDefinition);
    }
