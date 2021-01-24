    static void Main()
    {
    #if DEBUG
        var notifService = new NotificationService();
        notifService.OnStart();
    
        Console.WriteLine(@"Enter ""quit"" to terminate...");
        while ((Console.ReadLine()) != "quit");
    
        notifService.OnStop();
    #else
    .
    .
    .
    }
