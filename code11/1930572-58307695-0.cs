    // Method begins at RVA 0x2e64
    // Code size 30 (0x1e)
    .maxstack 1
    .locals init (
      [0] class ConsoleApp.Program/MainClass main
    )
    // (no C# code)
    IL_0000: nop
    // MainClass mainClass = new MainClass(new Test());
    IL_0001: newobj instance void ConsoleApp.Program/Test::.ctor()
    IL_0006: newobj instance void ConsoleApp.Program/MainClass::.ctor(class ConsoleApp.Program/Test)
    IL_000b: stloc.0
    // Console.WriteLine(mainClass.test.toAccess);
    IL_000c: ldloc.0
    IL_000d: ldfld class ConsoleApp.Program/Test ConsoleApp.Program/MainClass::test
    IL_0012: ldfld int32 ConsoleApp.Program/Test::toAccess
    IL_0017: call void [mscorlib]System.Console::WriteLine(int32)
    // (no C# code)
    IL_001c: nop
    // }
    IL_001d: ret
