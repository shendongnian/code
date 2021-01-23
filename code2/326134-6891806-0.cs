    Assembly SampleAssembly = Assembly.LoadFrom(filename);
    Type myType = SampleAssembly.GetTypes()[0];
    MethodInfo Method = myType.GetMethod("myVoid");
    object myInstance = Activator.CreateInstance(myType);
    Method.Invoke(myInstance, null);
    
