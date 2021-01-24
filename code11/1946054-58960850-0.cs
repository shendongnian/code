    static void Main(string[] args)
    {
        SynchronizationContext.SetSynchronizationContext(
            new WindowsFormsSynchronizationContext());
        EventHandler idleHandler = null;
        idleHandler = async (sender, e) =>
        {
            Application.Idle -= idleHandler;
            await MyMain(args);
            Application.ExitThread();
        };
        Application.Idle += idleHandler;
        Application.Run();
    }
