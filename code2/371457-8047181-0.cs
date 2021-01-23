    public static void DoEvents(this Application application)
    {
        Dispatcher.CurrentDispatcher.Invoke(DispatcherPriority.Background, new VoidHandler(() => { }));
    }
     
    private delegate void VoidHandler();
