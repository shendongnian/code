    public static void ShowProperties(object o)
    {
        if (o == null)
        {
            Console.WriteLine("Null: no properties");
            return;
        }
        Type type = o.GetType();
        var properties = type.GetProperties(BindingFlags.Public 
                                            | BindingFlags.Instance);
        // Potentially put more filtering in here
        foreach (var property in properties.Where
                     (p => p.CanRead && p.GetIndexParameters().Length == 0))
        {
            Console.WriteLine("{0}: {1}", property.Name, property.GetValue(o, null));
        }
    }
