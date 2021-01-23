    protected virtual PropertyPart Map(PropertyInfo property, string columnName)
    {
        PropertyPart propertyMap = new PropertyPart(property, typeof(T));
        if (!string.IsNullOrEmpty(columnName))
        {
            propertyMap.Column(columnName);
        }
        this.properties.Add(propertyMap);
        return propertyMap;
    }
