    PropertyInfo[] properties = type.GetProperties();
    while (reader.Read())
    {
        object obj = Activator.CreateInstance(type);
        foreach (PropertyInfo propertyInfo in properties)
        {
            propertyInfo.SetValue(obj, reader[propertyInfo.Name], null);
        }
        list.Add(obj);
    }
