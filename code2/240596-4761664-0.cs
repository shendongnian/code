    static bool IsAction(Type type)
    {
        if (type == typeof(System.Action)) return true;
        Type generic = null;
        if (type.IsGenericTypeDefinition) generic = type;
        else if (type.IsGenericType) generic = type.GetGenericTypeDefinition();
        if (generic == null) return false;
        if (generic == typeof(System.Action<>)) return true;
        if (generic == typeof(System.Action<,>)) return true;
        ... and so on ...
        return false;
    }
