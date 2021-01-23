    public static IDictionary<string, object> ObjectToDictionary(object instance)
    {
        var dictionary = new Dictionary<string, object>(StringComparer.OrdinalIgnoreCase);
        if (instance != null)
        {
            foreach (var descriptor in TypeDescriptor.GetProperties(instance))
            {
                object value = descriptor.GetValue(instance);
                dictionary.Add(descriptor.Name, value);
            }
        }
        return dictionary;
    }
