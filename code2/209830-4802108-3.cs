    // static (extension) method to read the property
    public static T GetProperty<T>(this DynamicClass self, string propertyName)
    {
        var type = self.GetType();
        var propInfo = type.GetProperty(propertyName);
        return (T)propInfo.GetValue(self, null);        
    }
    // usage:
    foreach (DynamicClass item in query)
    {
        // using as an extension method
        string ProductNumber      = item.GetProperty<string>("ProductNumber");
        // or as a static method
        string ProductDescription = GetProperty<string>(item, "ProductDescription");
        string Name               = item.GetProperty<string>("Name");
    }
