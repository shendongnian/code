    public App()
    {
        Console.WriteLine($"sc = {SynchronizationContext.Current?.ToString() ?? "null"}");
    }
    protected override void OnStartup(StartupEventArgs e)
    {
        Console.WriteLine($"sc = {SynchronizationContext.Current?.ToString() ?? "null"}");
        base.OnStartup(e);
    }
