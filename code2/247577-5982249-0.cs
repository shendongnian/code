        Assembly _assembly;
        _assembly = Assembly.GetExecutingAssembly();
        string[] names = _assembly.GetManifestResourceNames();
        foreach (string name in names)
           System.Console.WriteLine(name);
