    foreach (string fileName in pluginFiles)
    {
        Assembly assembly = Assembly.LoadFrom(fileName);
        List<Type> types = assembly.GetTypes().ToList();
        foreach (Type type in types.FindAll(t => t.GetInterface("IMFDBAnalyserPlugin") != null)
        {
            ...
        }
    }
