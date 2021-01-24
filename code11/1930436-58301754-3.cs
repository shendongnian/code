    private static Dictionary<string, string> getRelationPropertyAttribute<T>(Type type)
    {
        var dicRelation = new Dictionary<string, string>();
        var properties = type.GetProperties();
        foreach (var property in properties)
        {
            var customAttributes = property.GetCustomAttributes<T>();
            foreach (var attribute in customAttributes)
            {
                dicRelation[attr.Field] = property.Name;
            }
        }
        return dicRelation;
    }
