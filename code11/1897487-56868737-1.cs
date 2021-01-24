    public List<string> CbItems { get; }
    public string SelectedCbItem { get; set; }
    public MainWindow()
    {
        InitializeComponent();
        cbItems = new List<string> { "Option 1", "Option 2" };
        DataContext = this;
    }
