    public void CreateDynamicHandler()
    {
        var dynamicMethod = new DynamicMethod("DynamicMethod", null,
            new[] { typeof(MyClass), typeof(object), typeof(object) }, typeof(MyClass));
        var ilgen = dynamicMethod.GetILGenerator();
        ilgen.Emit(OpCodes.Ldarg_0);
        ilgen.Emit(OpCodes.Ldarg_1);
        ilgen.Emit(OpCodes.Ldarg_2);
        MethodInfo doSomethingElse = typeof(MyClass).GetMethod("DoSomethingElse",
            new[] { typeof(object), typeof(object) });
        ilgen.Emit(OpCodes.Call, doSomethingElse);
        ilgen.Emit(OpCodes.Ret);
        Delegate emitted = dynamicMethod.CreateDelegate(
            typeof(Action<MyClass, string, string>));
        emitted.DynamicInvoke(this, "Hello", "World");
    }
