    // int? x = null;
    ldloca.s 0
    initobj valuetype [mscorlib]System.Nullable`1<int32>
    // Console.WriteLine(x.Value);
    ldloca.s 0
    call instance !!0 [mscorlib]System.Nullable`1<int32>::get_Value()
    call void [mscorlib]System.Console::WriteLine(int32)
    // Console.WriteLine((int)x);
    ldloca.s 0
    call instance !!0 [mscorlib]System.Nullable`1<int32>::get_Value()
    call void [mscorlib]System.Console::WriteLine(int32)
