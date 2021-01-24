    static void Main(string[] args)
    {
        // The name of the key must include a valid root.
        const string userRoot = @"HKEY_CURRENT_USER\Software\Microsoft\Windows\CurrentVersion\Internet Settings";
        const string subkey = "SecureProtocols";
    
        //get the registry value.
        string result = (Registry.GetValue(userRoot, subkey, "Return this default if NoSuchName does not exist")).ToString();
        Console.WriteLine(result);
    
        //Enable TLS 1.0 and TLS 1.2 
        Registry.SetValue(userRoot, subkey, 2176);
    
        Console.WriteLine("OK");
        Console.ReadKey();
    }
