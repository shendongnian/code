    public static Type CompileResultType(string typeSignature)
    {
        TypeBuilder tb = GetTypeBuilder(typeSignature);
        tb.SetParent(typeof(DynamicControllerBase));
        ConstructorBuilder ctor = tb.DefineDefaultConstructor(MethodAttributes.Public | MethodAttributes.SpecialName | MethodAttributes.RTSpecialName);
        // For this controller, I only want a Get method to server Get request
        MethodBuilder myGetMethod =
            tb.DefineMethod("Get",
                MethodAttributes.Public,
                typeof(String), new Type[] { typeof(Test), typeof(String) });
        // Define parameters
        var parameterBuilder = myGetMethod.DefineParameter(
            position: 1, // 0 is the return value, 1 is the 1st param, 2 is 2nd, etc.
            attributes: ParameterAttributes.None,
            strParamName: "test"
        );
        var attributeBuilder
            = new CustomAttributeBuilder(typeof(FromServicesAttribute).GetConstructor(Type.EmptyTypes), Type.EmptyTypes);
        parameterBuilder.SetCustomAttribute(attributeBuilder);
        // Define parameters
        myGetMethod.DefineParameter(
            position: 2, // 0 is the return value, 1 is the 1st param, 2 is 2nd, etc.
            attributes: ParameterAttributes.None,
            strParamName: "stringParam"
        );
        // Generate IL for method.
        ILGenerator myMethodIL = myGetMethod.GetILGenerator();
        Func<string, string> method = (v) => "Poop";
        Func<Test, string, string> method1 = (v, s) => v.Name + s;
        myMethodIL.Emit(OpCodes.Jmp, method1.Method);
        myMethodIL.Emit(OpCodes.Ret);
        return tb.CreateType();
    }
