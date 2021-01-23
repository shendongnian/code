    CustomerViewModel
    {
        string ID { get; }
        string Name { get; set; }
        public static readonly CustomerViewModel All { get; private set; }
        
        static CustomerViewModel()
        {
           All = new CustomerViewModel();
        }
    
    
        private CustomerViewModel()
        {
        }
    
        public CustomerViewModel(Customer actualCustomer)
        {
        }
    }
    someOtherViewModel.Customers = new ObservableCollection<CustomerViewModel>();
    // add all the wrapping CustomerViewModel instances to the collection
    someOtherViewModel.Customers.Add(CustomerViewModel.All);
