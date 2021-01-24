    public Input()
    {
    }
    public async Task hello()
    {
        Console.WriteLine("some task");
        await Task.Delay(1000);
        Console.WriteLine("after some time");
        Console.ReadLine();
    }
