    .method private hidebysig static 
      void Main (
        string[] args
      ) cil managed 
    {
      // Method begins at RVA 0x2050
      // Code size 24 (0x18)
      .maxstack 2
      .entrypoint
      .locals init (
        [0] valuetype ConsoleApp1.Program/A value1,
        [1] valuetype ConsoleApp1.Program/A value2,
        [2] class [mscorlib]System.Collections.Generic.List`1<valuetype ConsoleApp1.Program/A> list
      )
      // (no C# code)
      IL_0000: nop
      // List<A> list = new List<A>();
      IL_0001: newobj instance void class [mscorlib]System.Collections.Generic.List`1<valuetype ConsoleApp1.Program/A>::.ctor()
      IL_0006: stloc.2
      // list.Add(item);
      IL_0007: ldloc.2
      IL_0008: ldloc.0
      IL_0009: callvirt instance void class [mscorlib]System.Collections.Generic.List`1<valuetype ConsoleApp1.Program/A>::Add(!0)
      // (no C# code)
      IL_000e: nop
      // list.Add(item2);
      IL_000f: ldloc.2
      IL_0010: ldloc.1
      IL_0011: callvirt instance void class [mscorlib]System.Collections.Generic.List`1<valuetype ConsoleApp1.Program/A>::Add(!0)
      // (no C# code)
      IL_0016: nop
      // }
      IL_0017: ret
    } // end of method Program::Main
