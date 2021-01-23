    public static void FillProperties<T>(T obj)
    {
        foreach (var property in typeof(T).GetProperties())
        {
            var attribute = property
                .GetCustomAttributes(typeof(DefaultValueAttribute), true)
                .Cast<DefaultValueAttribute>()
                .SingleOrDefault();
            if (attribute != null)
                property.SetValue(obj, attribute.Value, null);
        }
    }
