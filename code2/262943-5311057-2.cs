    static object Get(dynamic source, string memberName)
    {
        var prop = source.GetType().GetProperty(source.Type);
        object subObj = prop == null ? null : prop.GetValue(source, null);
        var subProp = subObj == null ? null : subObj.GetType().GetProperty(memberName);
        return subProp == null ? null : subProp.GetValue(subObj, null);
    }
