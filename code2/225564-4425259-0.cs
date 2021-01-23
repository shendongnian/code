    AppDomain ad = AppDomain.CreateDomain("myDomain");
    Assembly[] assemblies=ad.GetAssemblies();
    foreach (Assembly assembly in assemblies)
    {
    	Console.WriteLine(assembly.FullName);
    }
    Console.ReadKey();
