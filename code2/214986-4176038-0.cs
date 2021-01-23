        ObservableCollection<latlongobj> dataGrid2Items = new ObservableCollection<latlongobj>();
        public MainWindow()
        {
            InitializeComponent();
            dataGrid1.ItemsSource = idata;
            dataGrid2.ItemsSource = dataGrid2Items;
        }
        private void button1_Click(object sender, RoutedEventArgs e)
        {
            foreach (latlongobj item in dataGrid1.SelectedItems)
            {
                if( !dataGrid2Items.Contains( item ) )
                    dataGrid2Items.Add(item);
            }
        }
        private ObservableCollection<latlongobj> idata = new ObservableCollection<latlongobj>
            {
                new latlongobj{ name = "n1", Lat = 1, Lon = 2 },
                new latlongobj{ name = "n2", Lat = 2, Lon = 3 },
                new latlongobj{ name = "n3", Lat = 4, Lon = 5 },
            };
    
