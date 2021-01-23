    public class CustomerViewModel : WorkspaceViewModel, IDataErrorInfo
    {
	
        public CustomerViewModel(Customer customer, CustomerRepository customerRepository)
        {
            if (customer == null) throw new ArgumentNullException("customer");
            if (customerRepository == null) throw new ArgumentNullException("customerRepository");
            _customer = customer;
            _customerRepository = customerRepository;
         }
        readonly Customer _customer;
        public string Email
        {
            get { return _customer.Email; }
            set
            {
                if (value == _customer.Email) return;
                _customer.Email = value;
                base.OnPropertyChanged("Email");
            }
        }
        public override string DisplayName
        {
            get {
                if (IsNewCustomer)
                {
                    return Strings.CustomerViewModel_DisplayName;
                }
                ...
                return String.Format("{0}, {1}", _customer.LastName, _customer.FirstName);
            }
        }
 
        #region Save Command
        /// <summary>
        /// Returns a command that saves the customer.
        /// </summary>
        public ICommand SaveCommand
        {
            get
            {
                return _saveCommand ??
                       (_saveCommand = new RelayCommand(param => _save(), param => _canSave));
            }
        }
        RelayCommand _saveCommand;
        /// <summary>
        /// Returns true if the customer is valid and can be saved.
        /// </summary>
        bool _canSave
        {
            get { return String.IsNullOrEmpty(_validateCustomerType()) && _customer.IsValid; }
        }
        /// <summary>
        /// Saves the customer to the repository.  This method is invoked by the SaveCommand.
        /// </summary>
        void _save()
        {
            if (!_customer.IsValid)
                throw new InvalidOperationException(Strings.CustomerViewModel_Exception_CannotSave);
            if (IsNewCustomer)
                _customerRepository.AddCustomer(_customer);
            base.OnPropertyChanged("DisplayName");
        }
