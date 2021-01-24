    public IEnumerable<string> PropertiesFromType<T>(IEnumerable<T> input)
    {
        var item = input.First();
        var properties = new List<string>();
        foreach (PropertyInfo property in item.GetType().GetProperties())
        {
            properties.Add(property.Name);
        }
        return properties;
    }
