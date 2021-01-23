    foreach (PropertyInfo propertyInfo in Foo.GetType().GetProperties())
    {
        string propertyName = propertyInfo.Name;
        object[] attribute = propertyInfo.GetCustomAttributes(typeof(MyCustomAttribute), true);
        // Just in case you have a property without this annotation
        if (attribute.Length > 0)
        {
            MyCustomAttribute myAttribute = (MyCustomAttribute)attribute[0];
            string propertyValue = myAttribute.SomeProperty;
            // TODO: whatever you need with this propertyValue
        }
    }
