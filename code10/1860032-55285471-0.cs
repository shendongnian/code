    public async Task StartupAsync()
    {
        Console.WriteLine("Fetchstuff1");
        var aTask = GetStuff1Async();
        Console.WriteLine("Fetchstuff1stuff2");
        var bTask = GetStuff2Async();
        Console.WriteLine("Fetchstuff1stuff3");
        var cTask = GetStuff3Async();
        await Task.WhenAll(aTask, bTask, cTask);
        // DO STUFF AFTER ALL TASK OVER IS DONE
        var categories = GetCategories();
        var dt= CreateDatable();
        Sendtodatabase();
    }
