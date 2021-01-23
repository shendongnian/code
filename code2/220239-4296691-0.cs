    public MainWindow()
    {
        InitializeComponent();
    #if DEBUG
        button1.IsEnabled = false;
    #endif
    }
