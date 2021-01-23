    private static object ObjectFromString(object basePoint, IEnumerable<string> pathToSearch)
    {
        var value = basePoint;
        foreach (var propertyName in pathToSearch)
        {
            var property = value.GetType().GetProperty(propertyName);
            if (property == null) return null;
            value = property.GetValue(null, null);
        }
        return value;
    }
