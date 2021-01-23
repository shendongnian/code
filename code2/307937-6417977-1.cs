    call        System.Type.GetTypeFromHandle
    stloc.0     
    ldarg.0     
    ldfld       elementProperties
    ldloc.0     
    callvirt    System.Collections.Generic.Dictionary<System.Type,System.Reflection.PropertyInfo[]>.ContainsKey
    brfalse.s   IL_0028
    ldarg.0     
    ldfld       elementProperties
    ldloc.0     
    callvirt    System.Collections.Generic.Dictionary<System.Type,System.Reflection.PropertyInfo[]>.get_Item
    pop         
    br.s        IL_003A
    ldarg.0     
    ldfld       elementProperties
    ldloc.0     
    ldloc.0     
    callvirt    System.Type.GetProperties
    callvirt    System.Collections.Generic.Dictionary<System.Type,System.Reflection.PropertyInfo[]>.set_Item
