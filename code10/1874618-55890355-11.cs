    void ManualCancelation()
    {
        var infiniteAction = new InfiniteAction(Rogue.RogueFunction);
        Console.WriteLine("RogueFunction is executing.");
        infiniteAction.Start();
        Console.WriteLine("Press any key to stop it.");
        Console.ReadKey();
        Console.WriteLine();
        infiniteAction.Stop();
        Console.WriteLine("Make sure it has stopped and press any key to exit.");
        Console.ReadKey();
        Console.WriteLine();
    }
