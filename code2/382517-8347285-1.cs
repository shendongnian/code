    public static FieldInfo[] GetFieldsWithAttribute(Type type, Attribute attr, bool onlyFromType)
    {
        System.Reflection.FieldInfo[] infos = type.GetFields();
        var selection = 
           infos.Where(info =>
             (info.GetCustomAttributes(attr.GetType(), false).Length > 0) &&
             ((!onlyFromType) || (info.DeclaringType == type)));
        return selection.ToArray();
    }
