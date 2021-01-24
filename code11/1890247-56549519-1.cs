       DataTable dt1 = new DataTable();
       public MainWindow()
        {
            InitializeComponent();
            dt1 = new DataTable();
            dt1.Columns.Add("1");
            dt1.Columns.Add("2");
            dt1.Columns.Add("3");
            DataRow dr = dt1.NewRow();
            TheGrid.ItemsSource = dt1.DefaultView;
        }
        private void Remove_me(object sender, RoutedEventArgs e)
        {
            
            CheckBox checkbox = (CheckBox)sender;
            dt1.Columns.Remove(checkbox.Tag.ToString())
            TheGrid.ItemsSource = null;
            TheGrid.ItemsSource = dt1.DefaultView;
        }
