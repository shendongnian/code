    public static bool IsCollection(Type clrType, out Type elementType)
    {
        if (clrType == null)
        {
            throw Error.ArgumentNull("clrType");
        }
        elementType = clrType;
        // see if this type should be ignored.
        if (clrType == typeof(string))
        {
            return false;
        }
        Type collectionInterface
            = clrType.GetInterfaces()
                .Union(new[] { clrType })
                .FirstOrDefault(
                    t => TypeHelper.IsGenericType(t)
                            && t.GetGenericTypeDefinition() == typeof(IEnumerable<>));
        if (collectionInterface != null)
        {
            elementType = collectionInterface.GetGenericArguments().Single();
            return true;
        }
        return false;
    }
