    var assemblyBuilder = AppDomain.CurrentDomain.DefineDynamicAssembly(new AssemblyName("MyAssembly"),
        AssemblyBuilderAccess.RunAndSave);
    var modulBuilder = assemblyBuilder.DefineDynamicModule("MyModul");
    var longType = typeof(long);
    TypeBuilder typeBuilder = modulBuilder.DefineType("MyObjectChild", TypeAttributes.Class);
    FieldBuilder fieldBuilder = typeBuilder.DefineField("m_$id", longType, FieldAttributes.Private);
    var propertyBuilder = typeBuilder.DefineProperty("$id", PropertyAttributes.HasDefault, longType, null);
    MethodAttributes propertyAttributes = MethodAttributes.Public | MethodAttributes.SpecialName | MethodAttributes.HideBySig;
    MethodBuilder getBuilder = typeBuilder.DefineMethod("get_$id", propertyAttributes, longType, Type.EmptyTypes);
    ILGenerator getGen = getBuilder.GetILGenerator();
    getGen.Emit(OpCodes.Ldarg_0);
    getGen.Emit(OpCodes.Ldfld, fieldBuilder);
    getGen.Emit(OpCodes.Ret);
    //set method
    MethodBuilder setBuilder = typeBuilder.DefineMethod("set_$id", propertyAttributes, null, new [] { longType });
    ILGenerator setGen = setBuilder.GetILGenerator();
    setGen.Emit(OpCodes.Ldarg_0);
    setGen.Emit(OpCodes.Ldarg_1);
    setGen.Emit(OpCodes.Stfld, fieldBuilder);
    setGen.Emit(OpCodes.Ret);
    propertyBuilder.SetSetMethod(setBuilder);
    propertyBuilder.SetGetMethod(getBuilder);
    var createdType = typeBuilder.CreateType();
    var childObject = Activator.CreateInstance(createdType, BindingFlags.CreateInstance, null, new object[0],
        CultureInfo.InvariantCulture);
    var myNewType = childObject.GetType();
    foreach (var propertyInfo in myNewType.GetProperties())
    {
        // you can see the $id property there.
        Console.WriteLine(propertyInfo.Name);
    }
