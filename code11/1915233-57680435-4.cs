    public static bool IsCollection(Type clrType)
    {
        Type elementType;
        return TypeHelper.IsCollection(clrType, out elementType);
    }
