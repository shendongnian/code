    public MainWindow()
    {
        InitializeComponent();
        Adapters = new ObservableCollection<Netadapter>();
        // Add adapters
        this.DataContext = this;
    }
    public ObservableCollection<Netadapter> Adapters { get; set; }
