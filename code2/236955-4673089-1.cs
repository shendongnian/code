    // Omitted null checking, type validation, etc. for brevity
    static string GetNonGenericTypeName(Type genericType)
    {
        Type baseType = genericType.GetGenericTypeDefinition();
        // This is PROBABLY fine since the ` character is not allowed in C# for one of
        // your own types.
        int stopIndex = baseType.FullName.IndexOf('`');
        return baseType.FullName.Substring(0, stopIndex);
    }
