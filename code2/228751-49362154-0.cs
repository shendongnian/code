    public static void DoEvents()
    {
        Application.Current.Dispatcher.Invoke(DispatcherPriority.Render,
                                              new Action(delegate { }));
    }
