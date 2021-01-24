    //Load Assemblies
    //Get All assemblies.
    var refAssembyNames = Assembly.GetExecutingAssembly()
        .GetReferencedAssemblies();
    //Load referenced assemblies
    foreach (var asslembyNames in refAssembyNames)
    {
        Assembly.Load(asslembyNames);
    }
    Assembly[] assemblies = AppDomain.CurrentDomain.GetAssemblies();
    var myAssemblies = assemblies.Where(assem => assem.GetName().Name.Contains("VietWebSite.Data") || assem.GetName().Name.Equals("VietWebSite.Service"));
