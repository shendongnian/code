    var assemblies = projectAssemblyNames
        .Join(baseAssemblyNames, p => 1, b => 1, (p, b) => $"{p}.{b}")
        .Select(Load)
        .ToList();
    Assembly Load(string assembly) 
    {
        try
        {
            return Assembly.Load($"{projectAsm}.{baseAsm}");
        }
        catch 
        { 
             return null; // Not found
        }
    }
