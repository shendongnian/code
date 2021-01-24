    var properties = field.GetType().GetProperties();
    if (properties.Count() == 1)
    {
        var property = properties.Single();
        Console.WriteLine(property.Name);
        Console.WriteLine(property.GetValue(field));
    }
	
