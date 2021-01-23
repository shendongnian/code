    public static bool IsAssignableFrom(Type extendType, Type baseType)
    {
        while (!baseType.IsAssignableFrom(extendType))
        {
            if (extendType.Equals(typeof(object)))
            {
                return false;
            }
            if (extendType.IsGenericType && !extendType.IsGenericTypeDefinition)
            {
                extendType = extendType.GetGenericTypeDefinition();
            }
            else
            {
                extendType = extendType.BaseType;
            }
        }
        return true;
    }
