    public static bool TryParse(string value, out T returnedValue)
    {
        return TryParse(value, true, out returnedValue);
    }
    
    public static bool TryParse(string value, bool ignoreCase, out T returnedValue)
    {
        ...
    }
