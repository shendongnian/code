    public bool IsValid<T>(string propertyName, T propertyValue)
    {
        // ...
    }
    public bool IsValid<T>(string propertyName, T? propertyValue) where T : struct
    {
        // ...
    }
