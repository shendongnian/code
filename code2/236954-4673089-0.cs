    // Omitted null checking, type validation, etc. for brevity
    static string GetNonGenericTypeName(Type genericType)
    {
        Type baseType = genericType.GetGenericTypeDefinition();
        // This really ought to be fine since the ` character is not legal in a class
        // name for a type of your own.
        int stopIndex = baseType.FullName.IndexOf('`');
        return baseType.FullName.Substring(0, stopIndex);
    }
