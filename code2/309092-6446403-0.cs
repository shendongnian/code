        public MainWindow()
        {
            InitializeComponent();
            this.TestListBox.SelectionChanged += TestListBox_SelectionChanged;
            this.TestListBox.ItemsSource = Enumerable.Range(10, 10).ToList();
        }
        void TestListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            throw new NotImplementedException();
        }
