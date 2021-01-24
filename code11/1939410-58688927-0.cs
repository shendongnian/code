    new DispatcherTimer(
        TimeSpan.FromSeconds(1),
        DispatcherPriority.ApplicationIdle,
        (sender, args) =>
        {
        //...
        },
        Application.Current.Dispatcher)
            .Start();
