    public class AllCustomersViewModel : WorkspaceViewModel
    {
        public AllCustomersViewModel(CustomerRepository customerRepository)
        {
            if (customerRepository == null) throw new ArgumentNullException("customerRepository");
            _customerRepository = customerRepository;
            // Subscribe for notifications of when a new customer is saved.
            _customerRepository.CustomerAdded += OnCustomerAddedToRepository;
            // Populate the AllCustomers collection with CustomerViewModels.
            _createAllCustomers();              
        }
        /// <summary>
        /// Returns a collection of all the CustomerViewModel objects.
        /// </summary>
        public ObservableCollection<CustomerViewModel> AllCustomers
        {
            get { return _allCustomers; }
        }
        private ObservableCollection<CustomerViewModel> _allCustomers;
        void _createAllCustomers()
        {
            var all = _customerRepository
                .GetCustomers()
                .Select(cust => new CustomerViewModel(cust, _customerRepository))
                .ToList();
            foreach (var cvm in all)
                cvm.PropertyChanged += OnCustomerViewModelPropertyChanged;
            _allCustomers = new ObservableCollection<CustomerViewModel>(all);
            _allCustomers.CollectionChanged += OnCollectionChanged;
        }
        void OnCustomerViewModelPropertyChanged(object sender, PropertyChangedEventArgs e)
        {
            const string IsSelected = "IsSelected";
            // Make sure that the property name we're referencing is valid.
            // This is a debugging technique, and does not execute in a Release build.
            (sender as CustomerViewModel).VerifyPropertyName(IsSelected);
            // When a customer is selected or unselected, we must let the
            // world know that the TotalSelectedSales property has changed,
            // so that it will be queried again for a new value.
            if (e.PropertyName == IsSelected)
                OnPropertyChanged("TotalSelectedSales");
        }
 
        readonly CustomerRepository _customerRepository;
        void OnCustomerAddedToRepository(object sender, CustomerAddedEventArgs e)
        {
            var viewModel = new CustomerViewModel(e.NewCustomer, _customerRepository);
            _allCustomers.Add(viewModel);
        }
    }
