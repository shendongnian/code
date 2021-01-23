    public static bool IsSubclassOf(Type type, Type baseType)
    {
        if (type == null || baseType == null || type == baseType)
            return false;
    
        if (baseType.IsGenericType == false)
        {
            if (type.IsGenericType == false)
                return type.IsSubclassOf(baseType);
        }
        else
        {
            baseType = baseType.GetGenericTypeDefinition();
        }
    
        type = type.BaseType;
        Type objectType = typeof(object);
        while (type != objectType && type != null)
        {
            Type curentType = type.IsGenericType ?
                type.GetGenericTypeDefinition() : type;
            if (curentType == baseType)
                return true;
    
            type = type.BaseType;
         }
    
        return false;
    }
