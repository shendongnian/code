    private static string GetMessageFromResource(string resourceId)
    {
        var propertyInfo = typeof(DataResource).GetProperty(resourceId, BindingFlags.Static | BindingFlags.Public);
        return propertyInfo.GetValue(null, null);
    }
