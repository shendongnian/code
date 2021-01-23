    var currentAssembly = Assembly.GetExecutingAssembly();
    foreach (var method in currentAssembly.GetTypes().Where(type => type.IsClass)
                                          .SelectMany(cl => cl.GetMethods())
                                          .OfType<MethodBase>()
                                          .SelectMany(mb => mb.GetInstructions())
                                          .Select(inst => inst.Operand).OfType<MethodInfo>()
                                          .Where(mi => mi.Name == "<YourMethodName>"))
    {
        //here are your calls.
    }
