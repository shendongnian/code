    public List<int> Foo { get; set; }
    
            public MainWindow()
            {
                InitializeComponent();
                Foo = new List<int>() { 1, 2, 3 };
                MyGrid.ItemsSource = Foo;
            }
