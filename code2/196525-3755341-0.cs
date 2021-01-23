    public static void Main(string[] args)
    {
        AppDomain.CurrentDomain.AssemblyResolve += new ResolveEventHandler(CurrentDomain_AssemblyResolve);
        //do something
    }
    private static Assembly CurrentDomain_AssemblyResolve(object sender, ResolveEventArgs args)
    {
        Assembly.LoadFrom(fileName); // Load assembly from any file
        return assembly;
    }
