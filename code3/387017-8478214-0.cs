    allAssembliesMap.Add(assembly.GetName().Name, assembly);
    public IDictionary<string, Assembly> AllAssemblies 
    { 
        get 
        { 
           return allAssembliesMap; 
        } 
    }
