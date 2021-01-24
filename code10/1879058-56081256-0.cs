    public static IsNotOneOf(object obj, params Type[] types)
    {
        foreach (var type in types)
        {
            if (type.IsAssignableFrom(obj.GetType()) return false;
        }
        return true;
    }
