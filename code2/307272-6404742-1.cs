    private static void Main(string[] args)
    {
        Console.WriteLine("Trying to run method in current domain...");
        var inCurrentDomain = new Class1();
        inCurrentDomain.Go();
        Console.WriteLine("\nTrying to run method in remote domain...");
        string asmName = typeof(Class1).Assembly.FullName;
        string typeName = typeof (Class1).FullName;
        Console.WriteLine("Class1's assembly name is: {0}\nType name: {1}", asmName, typeName);
            
        var remoteDomain = AppDomain.CreateDomain("My remote domain");
        var remoteObject = (Class1)remoteDomain.CreateInstanceAndUnwrap(asmName, typeName);
        Console.WriteLine("\nRemote instance created. Running Go() method:");
        remoteObject.Go();
    }
