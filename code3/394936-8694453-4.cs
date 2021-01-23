    //ModuleBuilder module : a parameter passed into the containing function, the module which is being built (which contains the method that has the optional parameter we are setting the constant for)
    //Type optParam : A parameter passed into the containing function, the type of the nullable parameter, eg, typeof(Nullable<int>).
    IEnumerable<MethodInfo> info = typeof(TypeBuilder).GetMethods(BindingFlags.Static | BindingFlags.NonPublic).Where(m => m.Name == "SetConstantValue");
    var RuntimeHandle = typeof(ModuleBuilder).GetMethod("GetNativeHandle", BindingFlags.NonPublic | BindingFlags.Instance);
    foreach (var method in info)
    {
        if (method.GetParameters()[0].ParameterType.Name == "RuntimeModule")
        {
            method.Invoke(null, new object[]
            {
                RuntimeHandle.Invoke(module, new object[]{}),
                optParam.GetToken().Token,
                0x12,
                null
            });
        }
    }
