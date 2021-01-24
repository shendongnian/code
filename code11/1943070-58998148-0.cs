    private static TypeBuilder GetTypeBuilder(string assemblyName)
    {
        var assemName = new AssemblyName(assemblyName);
        var assemBuilder = AssemblyBuilder.DefineDynamicAssembly(assemName, AssemblyBuilderAccess.Run);
        // Create a dynamic module in Dynamic Assembly.
        var moduleBuilder = assemBuilder.DefineDynamicModule("DynamicModule");
        var tb = moduleBuilder.DefineType(assemblyName,
                TypeAttributes.Public |
                TypeAttributes.Class |
                TypeAttributes.AutoClass |
                TypeAttributes.AnsiClass |
                TypeAttributes.BeforeFieldInit |
                TypeAttributes.AutoLayout,
                null);
        return tb;
    }
