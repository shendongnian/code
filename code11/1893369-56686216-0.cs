    if (propertyInfo.PropertyType.IsInstanceOfType(items))
    {
        foreach (var item in (List<MessageItemData>) propertyInfo.GetValue(data))
        {
            Console.WriteLine(item);
        }
    }
