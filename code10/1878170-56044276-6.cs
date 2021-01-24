    private readonly Dictionary<Type, Dictionary<string, PropertyInfo>> _properties = new Dictionary<Type, Dictionary<string, PropertyInfo>>();
    private PropertyInfo GetProperty(Type sourceType, string propertyName)
    {
        if(!_properties.ContainsKey(sourceType))
            _properties.Add(sourceType, new Dictionary<string, PropertyInfo>());
        if (_properties[sourceType].ContainsKey(propertyName))
            return _properties[sourceType][propertyName];
        var property = sourceType.GetProperty(propertyName, BindingFlags.Instance | BindingFlags.Public);
        _properties[sourceType].Add(propertyName, property);
        return property; // could be null;
    }
