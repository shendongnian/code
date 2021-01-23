    public static Assembly GetAssemblyFromAppDomain(string assemblyName)
    {
        foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
        {
            if (assembly.FullName.StartsWith(assemblyName + ",")) 
            {
                return assembly;
            }
        }
        return null;   
    }
