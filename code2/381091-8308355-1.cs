    static Dictionary<Assembly, String> _Paths = new Dictionary<Assembly, String>();
    static void Main(string[] args)
    {
        AppDomain current = AppDomain.CurrentDomain;
        current.AssemblyResolve += new ResolveEventHandler(HandleAssemblyResolve);
        // This line loads a assembly and retrieves all types of it. Only when
        // calling "GetTypes" the 'AssemblyResolve'-event occurs and loads the dependency
        Type[] types = LoadAssembly("Assemblies\\MyDLL.dll").GetTypes();
        // The next line is used to test permissions, i tested the IO-Permissions 
        // and the Reflection permissions ( which should be denied when using remote assemblies )
        // Also this test includes the creation of a Form
        Object instance = Activator.CreateInstance(types[0]);
    }
    private static Assembly LoadAssembly(string file)
    {
        // Load the assembly
        Assembly result = Assembly.Load(File.ReadAllBytes(file));
        // Add the path of the assembly to the dictionary
        _Paths.Add(result, Path.GetDirectoryName(file));
        return result;
    }
    static Assembly HandleAssemblyResolve(object sender, ResolveEventArgs args)
    {
        // Extract file name from the full-quallified name
        String name = args.Name;
        name = name.Substring(0, name.IndexOf(','));
        // Load the assembly
        return LoadAssembly(Path.Combine(_Paths[args.RequestingAssembly], name + ".dll"));
    }
