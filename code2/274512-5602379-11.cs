    class CustomerHeaderViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Customer> Customers { get; set; }
    
        public void LoadCustomers()
        {
            ObservableCollection<Customer> customers = new ObservableCollection<Customer>();
    
            //this is where you would actually call your service
            customers.Add(new Customer { FirstName = "Jim", LastName = "Smith", NumberOfContracts = 23 });
            customers.Add(new Customer { FirstName = "Jane", LastName = "Smith", NumberOfContracts = 22 });
            customers.Add(new Customer { FirstName = "John", LastName = "Tester", NumberOfContracts = 33 });
            customers.Add(new Customer { FirstName = "Robert", LastName = "Smith", NumberOfContracts = 2 });
            customers.Add(new Customer { FirstName = "Hank", LastName = "Jobs", NumberOfContracts = 5 });
    
            Customers = customers;
        }
        protected void OnPropertyChanged(string porpName)
        {
            var temp = PropertyChanged;
            if (temp != null)
                temp(this, new PropertyChangedEventArgs(porpName));
        }
        public event PropertyChangedEventHandler PropertyChanged;
    
        private System.Windows.Media.Brush _foregroundColor = System.Windows.Media.Brushes.DarkSeaGreen;
    
        public System.Windows.Media.Brush ForegroundColor
        {
            get { return _foregroundColor; }
            set
            {
                _foregroundColor = value;
                OnPropertyChanged("ForegroundColor");
            }
        }
    }
