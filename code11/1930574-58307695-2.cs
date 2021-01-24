    .method public hidebysig specialname rtspecialname 
      instance void .ctor (
        class ConsoleApp.Program/TestClass test
      ) cil managed 
    {
      // Method begins at RVA 0x2e53
      // Code size 16 (0x10)
      .maxstack 8
      // (no C# code)
      IL_0000: ldarg.0
      IL_0001: call instance void [mscorlib]System.Object::.ctor()
      IL_0006: nop
      IL_0007: nop
      // this.test = test;
      IL_0008: ldarg.0
      IL_0009: ldarg.1
      IL_000a: stfld class ConsoleApp.Program/TestClass ConsoleApp.Program/MainClass::test
      // }
      IL_000f: ret
    } // end of method MainClass::.ctor
