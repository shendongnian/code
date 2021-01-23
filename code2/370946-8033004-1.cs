    public static object MyConvert(object value, Type t)
    {
        TypeConverter tc = TypeDescriptor.GetConverter(t);
        return tc.ConvertFrom(value);
    }
