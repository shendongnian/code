    using (SpringServiceHost serviceHost = new SpringServiceHost("calculator"))
    {
        serviceHost.Open();
    
        Console.Out.WriteLine("Server listening...");
        Console.Out.WriteLine("--- Press <return> to quit ---");
        Console.ReadLine();
    }
