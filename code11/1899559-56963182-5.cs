    .method public hidebysig instance void  M() cil managed
    {
      // Code size       25 (0x19)
      .maxstack  2
      .locals init (class [System.Collections]System.Collections.Generic.List`1<object> V_0)
      IL_0000:  nop
      IL_0001:  newobj     instance void class [System.Collections]System.Collections.Generic.List`1<object>::.ctor()
      IL_0006:  stloc.0
      IL_0007:  ldloc.0
      IL_0008:  brtrue.s   IL_000c
      IL_000a:  br.s       IL_0018
      IL_000c:  ldloc.0
      IL_000d:  newobj     instance void [System.Runtime]System.Object::.ctor()
      IL_0012:  call       instance void class [System.Collections]System.Collections.Generic.List`1<object>::Add(!0)
      IL_0017:  nop
      IL_0018:  ret
    } // end of method C::M
