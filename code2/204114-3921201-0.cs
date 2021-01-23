    .method public hidebysig static void  Main(string[] args) cil managed
    {
      .entrypoint
      // Code size       27 (0x1b)
      .maxstack  8
      IL_0000:  nop
      IL_0001:  ldc.i4.0
      IL_0002:  ldc.i4.s   10
      IL_0004:  call       class [mscorlib]System.Collections.Generic.IEnumerable`1<int32> [System.Core]System.Linq.Enumerable::Range(int32,
                                                                                                                                      int32)
      IL_0009:  call       int32 Test.Extensions::Count<int32>(class [mscorlib]System.Collections.Generic.IEnumerable`1<!!0>)
      IL_000e:  call       void [mscorlib]System.Console::WriteLine(int32)
      IL_0013:  nop
      IL_0014:  call       int32 [mscorlib]System.Console::Read()
      IL_0019:  pop
      IL_001a:  ret
    } // end of method Program::Main
