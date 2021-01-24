    public static void Reflecting(object obj)
    {
        foreach (var pi in obj.GetType().GetProperties())
        {
            if (pi.PropertyType.BaseType.IsGenericType
                && pi.PropertyType.BaseType.GetGenericTypeDefinition()
                == typeof(GenericClass<>))
            {
                var propValue = pi.GetValue(obj);
                if (propValue != null)
                {
                    var description = propValue.GetType()
                        .GetProperty("Description").GetValue(propValue);
                    Console.WriteLine(description);
                }
            }
        }
        Console.ReadKey();
    }
