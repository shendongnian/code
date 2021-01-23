    public static dynamic ConvertTo(this string input, Type type)
    {
        var converter = TypeDescriptor.GetConverter(type);
        if (converter != null)
        {
            try
            {
                return converter.ConvertFromString(input);
            }
            catch
            {
                // ignore
            }
        }
        if (type.IsValueType)
            return Activator.CreateInstance(type);
        return null;
    }
