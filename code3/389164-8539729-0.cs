    AppDomain.CurrentDomain.AssemblyResolve += (sender, prms) => {
        Console.WriteLine("Could not load assembly \"{0}\".", prms.Name);
        Console.ReadLine();
        Environment.Exit(1);
                
        return null;
    };
    Assembly.Load("this asembly does not exist");
