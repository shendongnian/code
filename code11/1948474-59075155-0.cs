            public MainWindow()
            {
                InitializeComponent();
    
                ListBox.Items.Add("Word1");
                ListBox.Items.Add("Word2");
                ListBox.Items.Add("Word3");
                ListBox.Items.Add("Word4");
    
                ListBox.SelectionChanged += ListBox_SelectionChanged;
            }
    
            private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
            {
                var listBoxValue = ListBox.SelectedValue.ToString();
                Console.WriteLine(listBoxValue);
            }
