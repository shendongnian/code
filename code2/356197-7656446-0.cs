    public static object ToEnum(this string s, Type type)
    {
        var eeType = typeof(EnumExt);
        var method = eeType.GetMethod("ToEnum", new[] { typeof(string) })
                           .MakeGenericMethod(type);
        return method.Invoke(null, new[] { s });
    }
