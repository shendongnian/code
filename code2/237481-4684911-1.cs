    var instance = new T();
   
    result.Read()
    var dictionary = new Dictionary<string, object>();
    
    // get the columns returned from database
    for (int i = 0; i < reader.FieldCount; i++)
    {
        string fieldName = reader.GetName(i);
        object value = reader.GetValue(i);
        dictionary.Add(fieldName, value);
    }
    
    // bind the columns from database to the properties of our object
    foreach (var c in columns)
    {
        var attr = c.Item2;
        var value = dictionary[attr.FieldName];
        if (value is DBNull)
        {
            value = null;
        }
        typeof(T).InvokeMember(c.Item1.Name, BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.SetProperty | BindingFlags.Instance, null, instance, new[] { value });
    }
    // return the new object with all its values filled out
    return instance
