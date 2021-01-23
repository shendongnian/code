    var assemblyBuilder = AppDomain.CurrentDomain.DefineDynamicAssembly(
      new AssemblyName("MyAssembly_" + Guid.NewGuid().ToString("N")), 
      AssemblyBuilderAccess.Run);
    
    var moduleBuilder = assemblyBuilder.DefineDynamicModule("Module");
    
    var typeBuilder = moduleBuilder.DefineType("MyType_" + Guid.NewGuid().ToString("N"), 
      TypeAttributes.Public));
    var methodBuilder = typeBuilder.DefineMethod("MyMethod", 
      MethodAttributes.Public | MethodAttributes.Static);
    
    expression.CompileToMethod(methodBuilder);
    
    var resultingType = typeBuilder.CreateType();
    
    var function = Delegate.CreateDelegate(expression.Type,
      resultingType.GetMethod("MyMethod"));
