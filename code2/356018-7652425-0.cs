    /// <summary>
    /// Returns all the (accessible) fields or properties that for a given type that
    /// have the "T" attribute declared on them.
    /// </summary>
    /// <param name="type">Type object to search</param>
    /// <returns>List of matching members</returns>
    public static List<MemberInfo> FindMembers<T>(Type type) where T : Attribute
    {
        return FindMembers<T>(type, MemberTypes.Field | MemberTypes.Property);
    }
    /// <summary>
    /// Returns all the (accessible) fields or properties that for a given type that
    /// have the "T" attribute declared on them.
    /// </summary>
    /// <param name="type">Type object to search</param>
    /// <returns>List of matching members</returns>
    public static List<MemberInfo> FindMembers<T>(Type type, MemberTypes memberTypesFlags) where T : Attribute
    {
        const BindingFlags FieldBindingFlags = BindingFlags.Instance | BindingFlags.NonPublic | BindingFlags.Public;
        List<MemberInfo> members = new List<MemberInfo>();
        members.AddRange(type.FindMembers(
                                memberTypesFlags,
                                FieldBindingFlags,
                                HasAttribute<T>, // Use delegate from below...
                                null)); // This arg is ignored by the delegate anyway...
        return members;
    }
    public static bool HasAttribute<T>(MemberInfo mi) where T : Attribute
    {
        return GetAttribute<T>(mi) != null;
    }
    public static bool HasAttribute<T>(MemberInfo mi, object o) where T : Attribute
    {
        return GetAttribute<T>(mi) != null;
    }
