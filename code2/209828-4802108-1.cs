    // static (extension) method to read the property
    public static T GetProperty<T>(this object self, string propertyName)
    {
        var type = self.GetType();
        var propInfo = type.GetProperty(propertyName);
        return (T)propInfo.GetValue(self, null);        
    }
    // usage:
    foreach (var item in query)
    {
        string ProductNumber      = item.GetProperty<string>("ProductNumber");
        string ProductDescription = GetProperty<string>(item, "ProductDescription");
        string Name               = item.GetProperty<string>("Name");
    }
