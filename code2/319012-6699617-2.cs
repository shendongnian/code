    public MainWindow()
    {
        InitializeComponent();
        var progressBar = new ProgressBar();
        progressBar.Height = 40;
        progressBar.Width = 200;
        progressBar.Margin = new Thickness(100, 100, 100, 100);
        Task.Factory.StartNew(() =>
        {
            // getLinks();
            for (var i = 0; i < 5; i++)
            {
                Dispatcher.Invoke(new Action(() => { progressBar.Value += 20; }));
                Thread.Sleep(500);
            }
        });
        var stackPanel = new StackPanel();
        stackPanel.Children.Add(progressBar);
        Content = stackPanel;
    }
