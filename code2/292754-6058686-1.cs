    IL_0035:  callvirt    System.Collections.Generic.List<UserQuery+SomeClass>.GetEnumerator
    IL_003A:  stloc.3     
    IL_003B:  br.s        IL_004B
    IL_003D:  ldloca.s    03 
    IL_003F:  call        System.Collections.Generic.List<UserQuery+SomeClass>.get_Current
    IL_0044:  stloc.1     
    IL_0045:  ldloc.1     
    IL_0046:  callvirt    UserQuery+SomeClass.someAction
    IL_004B:  ldloca.s    03 
    IL_004D:  call        System.Collections.Generic.List<UserQuery+SomeClass>.MoveNext
    IL_0052:  brtrue.s    IL_003D
    IL_0054:  leave.s     IL_0064
    IL_0056:  ldloca.s    03 
    IL_0058:  constrained. System.Collections.Generic.List<>.Enumerator
    IL_005E:  callvirt    System.IDisposable.Dispose
    IL_0063:  endfinally  
    IL_0064:  ret   
      
