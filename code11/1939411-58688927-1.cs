    new DispatcherTimer(
        TimeSpan.FromSeconds(1),
        DispatcherPriority.Normal,
        (sender, args) =>
        {
        //...
        },
        Application.Current.Dispatcher)
            .Start();
