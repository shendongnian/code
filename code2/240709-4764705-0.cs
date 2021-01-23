    var da = AppDomain.CurrentDomain.DefineDynamicAssembly(
        new AssemblyName("dyn"), // call it whatever you want
        AssemblyBindingFlags.Save); // I forget the actual enum name
    var dm = da.DefineModule("dyn_mod");
    var dt = dm.DefineType("dyn_type");
    var method = dt.DefineMethod(
        "Foo", 
        BindingFlags.Public | BindingFlags.Static);
    lambda.CompileTo(method);
    dt.CreateType();
    da.Save("C:\dyn.dll");
