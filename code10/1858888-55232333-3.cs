    public MainWindow()
            {
                InitializeComponent();
    
                personCombobox.ItemsSource = personRepository.GetAll();
                personCombobox.SelectedIndex = 0;
                
            }
     private void personCombobox_OnSelectionChanged(object sender, SelectionChangedEventArgs e)
            {
    
                if (personCombobox.SelectedIndex != -1)
                {
                    this.DataContext = (Person)personCombobox.Items.GetItemAt(personCombobox.SelectedIndex);
                }
            }  
    
