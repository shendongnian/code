    // Valid
    public Stream ConvertToStream<T>(T value)
    {
        return value as Stream;
    }
    // Invalid
    public Stream ConvertToStream(string value)
    {
        return value as Stream;
    }
    
