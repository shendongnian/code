        object unknown = //your com object...
        Type someComObjectType = typeof(ExampleTypeInInteropAssembly);
        Assembly interopAssembly = someComObjectType.Assembly;
        Func<Type, bool> implementsInterface = iface =>
        {
            try
            {
                Marshal.GetComInterfaceForObject(unknown, iface);
                return true;
            }
            catch (InvalidCastException)
            {
                return false;
            }
        };
        List<Type> supportedInterfaces = interopAssembly.
            GetTypes().
            Where(t => t.IsInterface).
            Where(implementsInterface).
            ToList();
        if (supportedInterfaces.Count > 0)
        {
            supportedInterfaces.ForEach(Console.WriteLine);
        }
        else
        {
            Console.WriteLine("No supported interfaces found :(");
        }
