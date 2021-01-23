    object Baan = null ;
    Type t;
    t = Type.GetTypeFromProgID("Baan4.Application.someuser");
    Baan = Activator.CreateInstance(t);
    object[] Parameters = new Object[1];
    Parameters[0] = 3600;
    //Baan.Timeout = 3600;
    Baan.GetType().InvokeMember("Timeout", 
                                BindingFlags.SetProperty, 
                                null, 
                                Baan, 
                                Parameters
    );
    Parameters = new Object[2];
    Parameters[0] = "otccomdll...";
    Parameters[1] = "function.name...";
    Baan.GetType().InvokeMember("ParseExecFunction", 
                                 BindingFlags.InvokeMethod, 
                                 null, 
                                 Baan, 
                                 Parameters
    );
    //your code here    
    //Baan.Quit();
    Baan.GetType().InvokeMember("Quit", BindingFlags.InvokeMethod, null, Baan, null);
