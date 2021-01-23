    AppDomain dom = AppDomain.CreateDomain("some");		
    AssemblyName assemblyName = new AssemblyName();
    assemblyName.CodeBase = pathToAssembly;
    Assembly assembly = dom.Load(assemblyName);
    Type [] types = assembly.GetTypes();
    AppDomain.Unload(dom);
