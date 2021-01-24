    private static Dictionary<T, string> getRelationPropertyAttribute<T>(Type type)
    {
        var dicRelation = new Dictionary<T, string>();
        var properties = type.GetProperties();
        foreach (var property in properties)
        {
            var customAttributes = property.GetCustomAttributes<T>();
            foreach (var attribute in customAttributes)
            {
                dicRelation[attr] = property.Name;
            }
        }
        return dicRelation;
    }
