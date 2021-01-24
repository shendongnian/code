    .method private hidebysig static 
      void Main (
        string[] args
      ) cil managed 
    {
      // Method begins at RVA 0x2050
      // Code size 40 (0x28)
      .maxstack 2
      .entrypoint
      .locals init (
        [0] valuetype ConsoleApp1.Program/A value1,
        [1] valuetype ConsoleApp1.Program/A value2,
        [2] class [mscorlib]System.Collections.Generic.List`1<valuetype ConsoleApp1.Program/A> list
      )
      // (no C# code)
      IL_0000: nop
      IL_0001: ldloca.s 0
      // A item = default(A);
      IL_0003: initobj ConsoleApp1.Program/A
      // (no C# code)
      IL_0009: ldloca.s 1
      // A item2 = default(A);
      IL_000b: initobj ConsoleApp1.Program/A
      // List<A> list = new List<A>();
      IL_0011: newobj instance void class [mscorlib]System.Collections.Generic.List`1<valuetype ConsoleApp1.Program/A>::.ctor()
      IL_0016: stloc.2
      // list.Add(item);
      IL_0017: ldloc.2
      IL_0018: ldloc.0
      IL_0019: callvirt instance void class [mscorlib]System.Collections.Generic.List`1<valuetype ConsoleApp1.Program/A>::Add(!0)
      // (no C# code)
      IL_001e: nop
      // list.Add(item2);
      IL_001f: ldloc.2
      IL_0020: ldloc.1
      IL_0021: callvirt instance void class [mscorlib]System.Collections.Generic.List`1<valuetype ConsoleApp1.Program/A>::Add(!0)
      // (no C# code)
      IL_0026: nop
      // }
      IL_0027: ret
    } // end of method Program::Main
