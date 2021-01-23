    static bool ContainsGenericClassInHierarchy(object value,
                                                Type genericTypeDefinition)
    {
        Type t = value.GetType();
        while (t != null)
        {
            if (t.IsGenericType
                && t.GetGenericTypeDefinition() == genericTypeDefinition)
            {
                return true;
            }
            t = t.BaseType;
        }
        return false;
    }
