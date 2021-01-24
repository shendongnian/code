      public MainWindow()
        {
            InitializeComponent();
            if (dc.DatabaseExists())
            {
                dataGrid1.ItemsSource = dc.TestTables;
            }
        }
