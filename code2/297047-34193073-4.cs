    private static void Set(string propertyName, string value)
    {
        var obj = new ClassA();
        obj.PropertyA = value;
    }
    private static void FastMember(string propertyName, string value)
    {
        var obj = new ClassA();
        var type = obj.GetType();
        var accessors = TypeAccessor.Create(type);
        accessors[obj, "PropertyA"] = "PropertyValue";
    }
    private static void SetValue(string propertyName, string value)
    {
        var obj = new ClassA();
        var propertyInfo = obj.GetType().GetProperty(propertyName);
        propertyInfo.SetValue(obj, value);
    }
    private static void SetMethodInvoke(string propertyName, string value)
    {
        var obj = new ClassA();
        var propertyInfo = obj.GetType().GetProperty(propertyName);
        propertyInfo.SetMethod.Invoke(obj, new object[] { value });
    }
