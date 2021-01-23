    private static Assembly MyResolveEventHandler(object sender, ResolveEventArgs args) {
        AssemblyName MissingAssembly = new AssemblyName(args.Name);
        CultureInfo ci = MissingAssembly.CultureInfo;
        
        ...
        resourceName = "MyApp.lib." + ci.Name.Replace("-","_") + "." + MissingAssembly.Name + ".dll";
        var stream = Assembly.GetExecutingAssembly().GetManifestResourceStream(resourceName)
        ...
    }
