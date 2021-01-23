    //Will load your assembly and all .Net core assemblies.
    foreach (var assembly in AppDomain.CurrentDomain.GetAssemblies())
    {
        Console.WriteLine("Going through " + assembly.Location);
        foreach(var type in assembly.GetTypes())
        {
            Console.WriteLine("Type " + type.FullName + " has the following methods:");
            for (var method in type.GetMethods())
            {
               // you can create another loop to go through all method arguments.
               Console.WriteLine(method.Name);
            }
        }
    }
