    public static object GetAttribute(System.Reflection.MemberInfo mi, System.Type t)
    {
        object[] objs = mi.GetCustomAttributes(t, true);
        if (objs == null || objs.Length < 1)
            return null;
        return objs[0];
    }
    public static T GetAttribute<T>(System.Reflection.MemberInfo mi)
    {
        return (T)GetAttribute(mi, typeof(T));
    }
    public delegate TResult GetValue_t<in T, out TResult>(T arg1);
    public static TValue GetAttributValue<TAttribute, TValue>(System.Reflection.MemberInfo mi, GetValue_t<TAttribute, TValue> value) where TAttribute : System.Attribute
    {
        TAttribute[] objAtts = (TAttribute[])mi.GetCustomAttributes(typeof(TAttribute), true);
        TAttribute att = (objAtts == null || objAtts.Length < 1) ? default(TAttribute) : objAtts[0];
        // TAttribute att = (TAttribute)GetAttribute(mi, typeof(TAttribute));
        if (att != null)
        {
            return value(att);
        }
        return default(TValue);
    }
