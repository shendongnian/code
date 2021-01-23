    .method public hidebysig static void  DoSomething<(class TestLib.IFoo`1<class TestLib.IChild>) T>(!!T foo) cil managed
    {
      .custom instance void [System.Core]System.Runtime.CompilerServices.ExtensionAttribute::.ctor() = ( 01 00 00 00 ) 
      // Code size       52 (0x34)
      .maxstack  1
      .locals init ([0] class TestLib.IFoo`1<class TestLib.IChild> bar)
      IL_0000:  nop
      IL_0001:  ldarg.0
      IL_0002:  box        !!T
      IL_0007:  call       void TestLib.Ext::DoSomethingElse(class TestLib.IFoo`1<class  TestLib.IBase>)
      IL_000c:  nop
      IL_000d:  ret
    } // end of method Ext::DoSomething
