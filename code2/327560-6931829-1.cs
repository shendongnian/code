    //int? x = 5;
    IL_0000:  ldloca.s    00 
    IL_0002:  ldc.i4.5    
    IL_0003:  call        System.Nullable<System.Int32>..ctor
    //Console.WriteLine(x.GetType());
    IL_0008:  ldloc.0     
    IL_0009:  box         System.Nullable<System.Int32>
    IL_000E:  callvirt    System.Object.GetType
    IL_0013:  call        System.Console.WriteLine
