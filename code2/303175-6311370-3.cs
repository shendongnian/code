    private ObservableCollection<Item> _items;
    public MainWindow()
    {
        InitializeComponent();
        _items = new ObservableCollection<Item>() { new Item("James"), new Item("John"), new Item("Steve"), new Item("Drew"), new Item("Andy"), new Item("James") };
        list.ItemsSource = _items;
    }
