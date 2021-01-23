    private static void RunFromBytes(byte[] bytes)
    {
    Assembly exeAssembly = Assembly.Load(bytes);
    var entryPoint = exeAssembly.EntryPoint;
    var parms = exeAssembly.CreateInstance(entryPoint.Name);
     entryPoint.Invoke(parms, null);
    }
