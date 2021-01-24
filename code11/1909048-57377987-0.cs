    private IJob GetClass(string nameSpace, string jobName)
    {
        // Use the file name to load the assembly into the current
        // application domain.
        Assembly a = Assembly.Load($"{nameSpace}.dll");
        // Get the type to use.
        Type myType = a.GetType($"{nameSpace}.{jobname}");
        // Create an instance.
        object obj = Activator.CreateInstance(myType);
        return (IJob)obj;
    }
