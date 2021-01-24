    public object Deserialize(string input, Type toType)
    {
        //here you need to deserialize 'input' string to value of 'toType' type.
        if(toType == typeof(int))
             return Int.Parse(input);
        if(toType == typeof(int?))
             return string.IsNullOrEmpty(input) ? (int?)null : Int.Parse(input);
        if(toType == typeof(string))
             return input;
        throw new NotImplementedException(toType.ToString());
    }
    //....
    string[] columns = line.Split('|');
    foreach (var column in columns)
    {
        var columnValue = column.Split('_');
        var prop = obj.GetType().GetProperty(columnValue[0]);
        if(prop == null)
            continue;
        prop.SetValue(obj, Deserialize(columntValue[1], prop.PropertyType));
    }
