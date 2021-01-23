    .method public hidebysig specialname instance void 
            add_OnCall(class [mscorlib]System.Func`2<int32,string> 'value') cil managed
    {
      // ...
      .locals init (class [mscorlib]System.Func`2<int32,string> V_0,
               class [mscorlib]System.Func`2<int32,string> V_1,
               class [mscorlib]System.Func`2<int32,string> V_2)
      IL_0000:  ldarg.0
      IL_0001:  ldfld      class [mscorlib]System.Func`2<int32,string> ConsoleApp1.Foo::OnCall
      // ...
      IL_000b:  call       class [mscorlib]System.Delegate [mscorlib]System.Delegate::Combine(class [mscorlib]System.Delegate,
                                                                                              class [mscorlib]System.Delegate)
      // ...
    } // end of method Foo::add_OnCall
