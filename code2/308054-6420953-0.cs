    public object GetProperty(object source, string path)
    {
        string[] bits = path.Split('.');
        Type type = source.GetType(); // Or pass this in
        object result = source;
        foreach (string bit in bits)
        {
            PropertyInfo prop = type.GetProperty(bit);
            type = prop.PropertyType;
            result = prop.GetValue(result, null);
        }
        return result;
    }
