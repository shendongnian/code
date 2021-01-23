    PropertyDescriptorCollection properties = TypeDescriptor.GetProperties(foo);
    
    foreach (PropertyDescriptor property in properties)
    {
        if (property.Name == "Name")
        {
            Console.WriteLine(property.DisplayName); // Something To Name
        }
    }
