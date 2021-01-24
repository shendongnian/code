    var propertyCollection = typeof(Number).GetProperties();
    foreach (var item in propertyCollection)
    {
        if (number.ContainsKey(item.Name.ToString()))
        {
            number[item.Name.ToString()] = Int32.Parse(item.GetValue(obj));
        }
    }
