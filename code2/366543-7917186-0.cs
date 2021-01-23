      Assembly SampleAssembly;
      SampleAssembly = Assembly.LoadFrom("c:\\Sample.Assembly.dll");
      MethodInfo Method = SampleAssembly.GetTypes()[0].GetMethod("Method1");
    // Obtain a reference to the parameters collection of the MethodInfo instance.
    ParameterInfo[] Params = Method.GetParameters();
    // Display information about method parameters.
    // Param = sParam1
    //   Type = System.String
    //   Position = 0
    //   Optional=False
    foreach (ParameterInfo Param in Params)
    {
        Console.WriteLine("Param=" + Param.Name.ToString());
        Console.WriteLine("  Type=" + Param.ParameterType.ToString());
        Console.WriteLine("  Position=" + Param.Position.ToString());
        Console.WriteLine("  Optional=" + Param.IsOptional.ToString());
    }
