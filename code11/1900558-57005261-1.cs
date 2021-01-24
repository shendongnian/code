    public static void Reflecting(object obj)
    {
        var t = obj.GetType();
        foreach (var pi in t.GetProperties())
        {
            if (pi.PropertyType.GetGenericTypeDefinition() == typeof(GenericClass<>))
            {
                var propValue = pi.GetValue(obj);
                var description = propValue.GetType()
                    .GetProperty("Description").GetValue(propValue);
                Console.WriteLine(description);
            }
        }
        Console.ReadKey();
    }
