    // Soner - tested!
    foreach (PropertyDescriptor descriptor in TypeDescriptor.GetProperties(item))
    {
        string name = descriptor.Name;              // Name
        object value = descriptor.GetValue(item);   // Value
        var type = descriptor.PropertyType;         // Type
        Console.WriteLine($"{name}={value}={type}");
    }
