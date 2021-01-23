    public MainWindow()
    {
        InitializeComponent();
    
        this.PreviewKeyDown += new KeyEventHandler(CloseOnEsc);
    }
    
    private void CloseOnEsc(object sender, KeyEventArgs e)
    {
        if (e.Key == Key.Escape)
            Close();
    }
