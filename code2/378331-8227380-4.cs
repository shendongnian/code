    public bool CanConvert<T>(string data)
    {
        TypeConverter converter = TypeDescriptor.GetConverter(typeof(T));
        return converter.IsValid(data);
    }
