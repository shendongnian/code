    .method public hidebysig specialname rtspecialname 
            instance void  .ctor(class EventTest.Publisher p) cil managed
    {
      // Code size       48 (0x30)
      .maxstack  8
      IL_0000:  ldarg.0
      IL_0001:  call       instance void [mscorlib]System.Object::.ctor()
      IL_0006:  nop
      IL_0007:  nop
      IL_0008:  ldarg.1
      IL_0009:  ldarg.0
      IL_000a:  ldftn      instance void EventTest.Subscriber::Respond(object)
      IL_0010:  newobj     instance void EventTest.Publisher/SomeEvent::.ctor(object,
                                                                              native int)
      IL_0015:  callvirt   instance void EventTest.Publisher::add_OnSomeEvent(class EventTest.Publisher/SomeEvent)
      IL_001a:  nop
      IL_001b:  ldarg.1
      IL_001c:  ldarg.0
      IL_001d:  ldftn      instance void EventTest.Subscriber::Respond(object)
      IL_0023:  newobj     instance void EventTest.Publisher/SomeEvent::.ctor(object,
                                                                              native int)
      IL_0028:  callvirt   instance void EventTest.Publisher::add_OnOtherEvent(class EventTest.Publisher/SomeEvent)
      IL_002d:  nop
      IL_002e:  nop
      IL_002f:  ret
    } 
