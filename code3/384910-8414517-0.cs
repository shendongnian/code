    Type type = Type.GetType("Mono.Runtime");
    if (type != null)
    {                                          
        MethodInfo dispalayName = type.GetMethod("GetDisplayName", BindingFlags.NonPublic | BindingFlags.Static); 
        if (dispalayName != null)                   
            Console.WriteLine(dispalayName.Invoke(null, null)); 
    }
