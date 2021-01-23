    var ab = AppDomain.CurrentDomain.DefineDynamicAssembly(
        new AssemblyName("foo"), AssemblyBuilderAccess.RunAndSave);
    var mb = ab.DefineDynamicModule("foo");
    var tb = mb.DefineType("bar");
    tb.AddInterfaceImplementation(typeof(IFoo));
    var method = typeof(IFoo).GetProperty("Property").GetGetMethod();
    var impl = tb.DefineMethod("impl",
        MethodAttributes.Private | MethodAttributes.Virtual,
        typeof(int), Type.EmptyTypes);
    var il = impl.GetILGenerator();
    il.Emit(OpCodes.Ldc_I4_7); // because it is lucky
    il.Emit(OpCodes.Ret);
    tb.DefineMethodOverride(impl, method);
    var type = tb.CreateType();
    IFoo foo = (IFoo)Activator.CreateInstance(type);
    var val = foo.Property;
