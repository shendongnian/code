    public MainWindow()
    {
        InitializeComponent();
        this.DataContext = this;
        Items = new List<ItemVM>
                    {
                        new ItemVM {IsSelected = false, Name = "Firefox"},
                        new ItemVM {IsSelected = false, Name = "Chrome"},
                        new ItemVM {IsSelected = false, Name = "IE"}
                    };
    }
    public IEnumerable<ItemVM> Items { get; set; }
    private IEnumerable<ItemVM> _selectedItems;
    public IEnumerable<ItemVM> SelectedItems
    {
        get { return _selectedItems; }
        set
        {
            _selectedItems = value;
            if (PropertyChanged != null)
                this.PropertyChanged(this, new PropertyChangedEventArgs("SelectedItems"));
        }
    }
    private void EvaluateSelectedItems(object sender, RoutedEventArgs e)
    {
        SelectedItems = Items.Where(item => item.IsSelected);
    }
