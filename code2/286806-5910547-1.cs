    .method private hidebysig static void  Main(string[] args) cil managed
    {
      .entrypoint
      // Code size       27 (0x1b)
      .maxstack  3
      .locals init ([0] class [mscorlib]System.Collections.Generic.Dictionary`2<string,object> dictionary,
               [1] class [mscorlib]System.Collections.Generic.Dictionary`2<string,object> '<>g__initLocal0')
      IL_0000:  nop
      IL_0001:  newobj     instance void class [mscorlib]System.Collections.Generic.Dictionary`2<string,object>::.ctor()
      IL_0006:  stloc.1
      IL_0007:  ldloc.1
      IL_0008:  ldstr      "Ali"
      IL_000d:  ldstr      "Ostad"
      IL_0012:  callvirt   instance void class [mscorlib]System.Collections.Generic.Dictionary`2<string,object>::Add(!0,
                                                                                                                     !1)
      IL_0017:  nop
      IL_0018:  ldloc.1
      IL_0019:  stloc.0
      IL_001a:  ret
    } // end of method Program::Main
