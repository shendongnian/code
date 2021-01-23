    if(method.IsSpecialName && method.Name.StartsWith("set_"))
    {
        var prop = typeof (Foo).GetProperty(method.Name.Substring(4),
               BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);
        var accessor = prop.GetSetMethod();
        bool isSame = accessor == method;
    }
