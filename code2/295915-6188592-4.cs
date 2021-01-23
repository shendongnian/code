    public MainWindowViewModel()
    {
        IsLoading = true;
        DispatcherTimer t = new DispatcherTimer();
        t.Interval = TimeSpan.FromSeconds(5);
        t.Tick += (s, e) => IsLoading = !IsLoading;
        t.Start();
    }
