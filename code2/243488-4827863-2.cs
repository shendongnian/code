    .class public auto ansi beforefieldinit test.MyClass2
           extends [mscorlib]System.Object
    {
      .field public class test.MyObject MyObject
      .method public hidebysig specialname rtspecialname 
              instance void  .ctor() cil managed
      {
        // code size:       21 (0x15)
        .maxstack  8
        IL_0000:  ldarg.0
        IL_0001:  call       instance void [mscorlib]System.Object::.ctor()
        IL_0006:  nop
        IL_0007:  nop
        IL_0008:  ldarg.0
        IL_0009:  newobj     instance void test.MyObject::.ctor()
        IL_000e:  stfld      class test.MyObject test.MyClass2::MyObject
        IL_0013:  nop
        IL_0014:  ret
      } // end of method MyClass2::.ctor
    } // end of class test.MyClass2
