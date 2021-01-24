    JToken propertyValue = property.Value;
    if (propertyValue.Type == JTokenType.Array)
    {
        Console.WriteLine("Array"); //Further Manipulations
    }
    else
    {
        Console.WriteLine("NAME :" + property.Name);
    }
