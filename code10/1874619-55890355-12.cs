    void ByTimerCancelation()
    {
        var interval = 3000;
        var infiniteAction = new InfiniteAction(Rogue.RogueFunction);
        Console.WriteLine($"RogueFunction is executing and will be stopped in {interval} ms.");
        Console.WriteLine("Make sure it has stopped and press any key to exit.");
        infiniteAction.Start();
        var timer = new Timer(StopInfiniteAction, infiniteAction, interval, -1);
        Console.ReadKey();
        Console.WriteLine();
    }
    private void StopInfiniteAction(object action)
    {
        var infiniteAction = action as InfiniteAction;
        if (infiniteAction != null)
            infiniteAction.Stop();
        else
            throw new ArgumentException($"Invalid argument {nameof(action)}");
    }
