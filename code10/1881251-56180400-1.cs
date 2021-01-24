    public static Object TryConvertTo<T>(string input)
    {
        Object result = null;
        try
        {
            result = Convert.ChangeType(input, typeof(T));
        }
        catch
        {
        }
    
        return result;
    }
