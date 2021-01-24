    public static void Reflecting(object obj)
    {
        var t = obj.GetType();
        foreach (var pi in t.GetProperties())
        {
            var type1 = pi.PropertyType.BaseType;
            var type2 = typeof(GenericClass<>);
            if (type1.Assembly.Equals(type2.Assembly) && type1.Namespace.Equals(type2.Namespace) && type1.Name.Equals(type2.Name))
            {
                var propValue = pi.GetValue(obj);
                var description = propValue.GetType().GetProperty("Description").GetValue(propValue);
                Console.WriteLine(description);
            }
        }
        Console.ReadKey();
    }
