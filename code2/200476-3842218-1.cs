    .method private hidebysig static void MethodGroup() cil managed
    {
        .maxstack 8
        L_0000: newobj instance void [mscorlib]System.Collections.Generic.List`1<string>::.ctor()
        L_0005: ldnull 
        L_0006: ldftn void [mscorlib]System.Console::WriteLine(string)
        L_000c: newobj instance void [mscorlib]System.Action`1<string>::.ctor(object, native int)
        L_0011: call instance void [mscorlib]System.Collections.Generic.List`1<string>::ForEach(class [mscorlib]System.Action`1<!0>)
        L_0016: ret 
    }
    
    .method private hidebysig static void LambdaExpression() cil managed
    {
        .maxstack 8
        L_0000: newobj instance void [mscorlib]System.Collections.Generic.List`1<string>::.ctor()
        L_0005: ldsfld class [mscorlib]System.Action`1<string> Sandbox.Program::CS$<>9__CachedAnonymousMethodDelegate1
        L_000a: brtrue.s L_001d
        L_000c: ldnull 
        L_000d: ldftn void Sandbox.Program::<LambdaExpression>b__0(string)
        L_0013: newobj instance void [mscorlib]System.Action`1<string>::.ctor(object, native int)
        L_0018: stsfld class [mscorlib]System.Action`1<string> Sandbox.Program::CS$<>9__CachedAnonymousMethodDelegate1
        L_001d: ldsfld class [mscorlib]System.Action`1<string> Sandbox.Program::CS$<>9__CachedAnonymousMethodDelegate1
        L_0022: call instance void [mscorlib]System.Collections.Generic.List`1<string>::ForEach(class [mscorlib]System.Action`1<!0>)
        L_0027: ret 
    }
