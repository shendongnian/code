    List<ComboBox> allCmbx = new List<ComboBox>();
            List<string> allItems = new List<string> { "1", "2", "3", "4", "5" };
            public MainWindow()
            {
                InitializeComponent();
    
    
                ComboBox comboBox = new ComboBox();
                comboBox.ItemsSource = allItems;
                comboBox.DropDownClosed += ComboBox_DropDownClosed;
                stackPanel.Children.Add(comboBox);
                allCmbx.Add(comboBox);
    
    
            }
    
            private void ComboBox_DropDownClosed(object sender, EventArgs e)
            {
    
                ComboBox mainComboBox = (ComboBox)sender;
                mainComboBox.DropDownClosed -= ComboBox_DropDownClosed;
                ComboBox comboBox = new ComboBox();
                allItems.Remove(mainComboBox.SelectedItem.ToString());
                comboBox.ItemsSource = allItems;
                comboBox.DropDownClosed += ComboBox_DropDownClosed;
                stackPanel.Children.Add(comboBox);
                allCmbx.Add(comboBox);
            }
     
    
     
