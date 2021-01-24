    private ObservableCollection<string> items;
    public ObservableCollection<string> Items
    {
        get { return items; }
        set { items = value; OnPropertyChanged(); }
    }
    public void LoadExpanderData(object obj)
    {
        Items = new ObservableCollection<string>();
        Items.Add("Item 1");
        Items.Add("Item 2");
        Items.Add("Item 3");
        Items.Add("Item 4");
        Items.Add("Item 5");
    }
