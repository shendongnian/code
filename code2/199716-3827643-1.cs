    // Resources dll
    var assembly = Assembly.LoadFrom("ResourcesLib.DLL");
    // Resource file.. namespace.ClassName
    var rm = new ResourceManager("ResourcesLib.Messages", assembly);
    // Now you can get the values
    var x = rm.GetString("Hi");
