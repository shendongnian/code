    var assemblies = projectAssemblyNames
        .Join(baseAssemblyNames, p => 1, b => 1, (p, b) => $"{p}.{b}")
        .Select(Load).Where(a => a != null) // remove null from list
        .ToList();
    Assembly Load(string assembly) 
    {
        try
        {
            return Assembly.Load(assembly);
        }
        catch 
        { 
             return null; // Not found
        }
    }
