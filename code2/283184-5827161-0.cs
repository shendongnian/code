        List<string> namespaces = new List<string>();
        List<Assembly> assemblies = new List<Assembly>();
        assemblies.Add(Assembly.GetExecutingAssembly());
        foreach (var asn in Assembly.GetExecutingAssembly().GetReferencedAssemblies()) {
            assemblies.Add(Assembly.Load(asn));
        }
        foreach (var ass in assemblies)
        {
            foreach (Type t in ass.GetTypes())
            {
                if (!namespaces.Contains(t.Namespace))
                {
                    namespaces.Add(t.Namespace);
                    Console.WriteLine(t.Namespace);
                }
            }
        }
