        ObservableCollection<uu> list = new ObservableCollection<uu>();        
        
        MainWindow()
        {
            InitializeComponent();
            // Set the listbox's ItemsSource to your new ObservableCollection
            ListBox.ItemsSource = list;
        }
        public void SetAllFalse()
        {
            foreach (uu item in this.list)
            {
                item.Ck = false;
            }
        }
