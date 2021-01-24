    .method public hidebysig instance void  M2() cil managed
    {
      // Code size       30 (0x1e)
      .maxstack  2
      .locals init (class [System.Collections]System.Collections.Generic.List`1<object> V_0,
               bool V_1)
      IL_0000:  nop
      IL_0001:  newobj     instance void class [System.Collections]System.Collections.Generic.List`1<object>::.ctor()
      IL_0006:  stloc.0
      IL_0007:  ldloc.0
      IL_0008:  ldnull
      IL_0009:  cgt.un
      IL_000b:  stloc.1
      IL_000c:  ldloc.1
      IL_000d:  brfalse.s  IL_001d
      IL_000f:  nop
      IL_0010:  ldloc.0
      IL_0011:  newobj     instance void [System.Runtime]System.Object::.ctor()
      IL_0016:  callvirt   instance void class [System.Collections]System.Collections.Generic.List`1<object>::Add(!0)
      IL_001b:  nop
      IL_001c:  nop
      IL_001d:  ret
    } // end of method C::M2
