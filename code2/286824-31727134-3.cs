    public static dynamic ToDynamic(this object item)
    {
        var dictionary = new ExpandoObject() as IDictionary<string, object>;
        foreach (var propertyInfo in item.GetType().GetProperties())
            dictionary[propertyInfo.Name] = propertyInfo.GetValue(item, null);
        return dictionary as ExpandoObject;
    }
