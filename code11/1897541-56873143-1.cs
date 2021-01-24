    private ObservableCollection<Customer> customers;
        public ObservableCollection<Customer> Customers
        {
            get
            {
                return customers;
            }
            set
            {
                if (customers == value)
                    return;
                customers = value;
                RaisePropertyChanged("Customers");
            }
       }
