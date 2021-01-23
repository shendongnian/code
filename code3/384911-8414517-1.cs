    Type type = Type.GetType("Mono.Runtime");
    if (type != null)
    {                                          
        MethodInfo displayName = type.GetMethod("GetDisplayName", BindingFlags.NonPublic | BindingFlags.Static); 
        if (displayName != null)                   
            Console.WriteLine(displayName.Invoke(null, null)); 
    }
