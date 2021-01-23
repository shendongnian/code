    private static bool OpenGenericTypeImplementsOpenGenericInterface(
        Type derivedType, Type interfaceType)
    {
        return derivedType.GetInterface(interfaceType.Name) != null;
    }
