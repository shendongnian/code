    Icall       System.Type.GetTypeFromHandle
    callvirt    System.Collections.Generic.Dictionary<System.Type,System.Reflection.PropertyInfo[]>.ContainsKey
    brfalse.s   IL_002F
    ldarg.0     
    ldfld       elementProperties
    ldtoken     01 00 00 1B 
    call        System.Type.GetTypeFromHandle
    callvirt    System.Collections.Generic.Dictionary<System.Type,System.Reflection.PropertyInfo[]>.get_Item
    pop         
    br.s        IL_0053
    ldarg.0     
    ldfld       elementProperties
    ldtoken     01 00 00 1B 
    call        System.Type.GetTypeFromHandle
    ldtoken     01 00 00 1B 
    call        System.Type.GetTypeFromHandle
    call        System.Type.GetProperties
    callvirt    System.Collections.Generic.Dictionary<System.Type,System.Reflection.PropertyInfo[]>.set_Item
