    public void Export<T>(T exportObject)
    {
        var properties = typeof(T).GetProperties(BindingFlags.Public | BindingFlags.Instance);
        foreach (var property in properties)
        {
            var attributes = Attribute.GetCustomAttributes(property, false);
            foreach (var attribute in attributes)
            {
                if (attribute is MyCustomAttribute)
                {
                    if (((MyCustomAttribute)attribute).Exportable)
                    {
                    }
                }
                if (attribute is MyCustomAttribute2)
                {
                    if (((MyCustomAttribute2)attribute).AnotherThing)
                    {
                    }
                }
            }
        }
    }
