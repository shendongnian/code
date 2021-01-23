    public void DoEvents()
    {
        Application.Current.Dispatcher.Invoke(DispatcherPriority.Background, new Action(() =>
        {
            code;
            DoEvents();
        }));
    }
