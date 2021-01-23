    PropertyInfo propertyInfo = typeof(Foo).GetProperty(propertyToCheck);
    object[] attribute = propertyInfo.GetCustomAttributes(typeof(MyCustomAttribute), true);
    if (attribute.Length > 0)
    {
        MyCustomAttribute myAttribute = (MyCustomAttribute)attribute[0];
        string propertyValue = myAttribute.SomeProperty;
    }
