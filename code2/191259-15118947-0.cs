    if(obj.GetType().Assembly.FullName.Contains("MyAssembly"))
    {
        //User-defined type
    }
    else if(obj.GetType().FullName.StartsWith("System."))
    {
        //.NET type
    }
