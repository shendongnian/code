    public static object GetValidatedValue(string param, Type type)
    {
        return TryParse(param, type);
    }
    
    private static object TryParse(string inValue, Type type)
    {
        var converter = TypeDescriptor.GetConverter(type);
    
        try
        {
            return converter.ConvertFromString(null, CultureInfo.InvariantCulture, inValue);
        }
        catch
        {
            return default(T);
        }
    }
