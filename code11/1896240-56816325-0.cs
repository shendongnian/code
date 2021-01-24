    public MainWindow()
    {
        InitializeComponent();
        this.Loaded += MainWindow_OnLoaded;
    }
    
    private void MainWindow_OnLoaded(object sender, RoutedEventArgs e)
    {
        SteamAPI.Init();
        var name = SteamFriends.GetPersonaName();
    
        personNameTextBox.Text = name;
    }
