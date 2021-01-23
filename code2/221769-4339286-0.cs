        object unknown = //your com object...
        Type someComObjectType = typeof(ExampleTypeInInteropAssembly);
        Assembly interopAssembly = someComObjectType.Assembly;
        Type unknownType = unknown.GetType();
        List<Type> supportedInterfaces = interopAssembly.
            GetTypes().
            Where(t => t.IsInterface).
            Where(i => i.IsAssignableFrom(unknownType)).
            ToList();
        if (supportedInterfaces.Count > 0)
        {
            supportedInterfaces.ForEach(Console.WriteLine);
        }
        else
        {
            Console.WriteLine("No supported interfaces found :(");
        }
