    if(method.IsSpecialName && method.Name.StartsWith("set_"))
    {
        var prop = typeof (Foo).GetProperty(method.Name.Substring(4),
               BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);
        var getter = prop.GetSetMethod();
        bool isSame = getter == method;
    }
