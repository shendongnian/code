    public static Type GetItemType(this Type collectionType)
    {
        var types =
            (from method in collectionType.GetMethods()
             where method.Name == "get_Item"
             select method.ReturnType
            ).Distinct().ToArray();
        if (types.Length == 0)
            return null;
        if (types.Length != 1)
            throw new Exception(string.Format("{0} has multiple item types", collectionType.FullName));
        return types[0];
    }
