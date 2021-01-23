    public MainWindow()
    {
        InitializeComponent();
    
        this.PreviewKeyDown += new KeyEventHandler(HandleEsc);
    }
    
    private void HandleEsc(object sender, KeyEventArgs e)
    {
        if (e.Key == Key.Escape)
            Close();
    }
