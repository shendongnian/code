    AppDomain currDom = AppDomain.CurrentDomain;
    AssemblyName aName = new AssemblyName();
    aName.Name = "YourAssemblyName";
    AssemblyBuilder assemblyBuilder = currDom.DefineDynamicAssembly(aName, AssemblyBuilderAccess.Run); // We need Run access, don't need Save access
    ModuleBuilder mb = assemblyBuilder.DefineDynamicModule(aName.Name); // Here we define transient dynamic module in assembly
    
    TypeBuilder tb = mb.DefineType("YourTypeName");
    tb.CreateType();       
    
    // Define your type definition here
    // ...
    
    Type t = assemblyBuilder.GetType("YourTypeName", true); // Load created type using our AssemblyBuilder instance
    Console.WriteLine("Loaded type \"{0}\".", t);
    Object o = Activator.CreateInstance(t); // Create object of loaded type
    Console.WriteLine("Created object \"{0}\".", o.ToString());
