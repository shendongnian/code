    protected void Test()
    {
        Type t = typeof(Container);
        string propertyList = string.Join(",", IteratePropertiesRecursively("", t).ToArray<string>());
        // do something with propertyList
    }
    protected IEnumerable<string> IteratePropertiesRecursively(string prefix, Type t)
    {
        if (!string.IsNullOrEmpty(prefix) && !prefix.EndsWith(".")) prefix += ".";
        prefix += t.Name + ".";
        
        // enumerate the properties of the type
        foreach (PropertyInfo p in t.GetProperties())
        {
            Type pt = p.PropertyType;
            // if property is a generic list
            if (pt.Name == "List`1")
            {
                Type genericType = pt.GetGenericArguments()[0];
                // then enumerate the generic subtype
                foreach (string propertyName in IteratePropertiesRecursively(prefix, genericType))
                {
                    yield return propertyName;
                }
            }
            else
            {
                // otherwise enumerate the property prepended with the prefix
                yield return prefix + p.Name;
            }
        }
    }
