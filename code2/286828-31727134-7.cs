    public static dynamic ToDynamic(this object item)
    {
        var expando = new ExpandoObject() as IDictionary<string, object>;
        foreach (var propertyInfo in item.GetType().GetProperties())
            expando[propertyInfo.Name] = propertyInfo.GetValue(item, null);
        return expando;
    }
