    public ObservableCollection<ComboBoxItem> cbItems { get; set; }
    public ComboBoxItem SelectedcbItem { get; set; }
    public MainWindow()
    {
        InitializeComponent();
        DataContext = this;
        cbItems = new ObservableCollection<ComboBoxItem>();
        var cbItem = new ComboBoxItem { Content = "<--Select-->" };
        SelectedcbItem = cbItem;
        cbItems.Add(cbItem);
        cbItems.Add(new ComboBoxItem { Content = "Option 1" });
        cbItems.Add(new ComboBoxItem { Content = "Option 2"});
    }
