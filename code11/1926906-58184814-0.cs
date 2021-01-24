    public MainPage()
    {
        InitializeComponent();
        Loaded += OnLoaded;
    }
    private async void OnLoaded(object sender, RoutedEventArgs e)
    {
	    Loaded -= OnLoaded;
        string b = await Serial();
        textblock_Rx_live.Text = b;
    }
