    public class AddCustomerViewModel : ViewModelBase, INotifyDataErrorInfo
    {
        private readonly Dictionary<string, ICollection<string>> _validationErrors 
            = new Dictionary<string, ICollection<string>>();
        private readonly Customer _customer;
        public AddCustomerViewModel(Customer customer)
        {
            _customer = customer;
        }
        [Required(ErrorMessage = "You must enter a name.")]
        public string Name
        {
            get { return _customer.Name; }
            set { _customer.Name = value; ValidateModelProperty(value, nameof(Name)); }
        }
        //+ ID and Address
        private void ValidateModelProperty(object value, string propertyName)
        {
            if (_validationErrors.ContainsKey(propertyName))
                _validationErrors.Remove(propertyName);
            ICollection<ValidationResult> validationResults = new List<ValidationResult>();
            ValidationContext validationContext =
                new ValidationContext(this, null, null) { MemberName = propertyName };
            if (!Validator.TryValidateProperty(value, validationContext, validationResults))
            {
                _validationErrors.Add(propertyName, new List<string>());
                foreach (ValidationResult validationResult in validationResults)
                {
                    _validationErrors[propertyName].Add(validationResult.ErrorMessage);
                }
            }
            RaiseErrorsChanged(propertyName);
        }
        #region INotifyDataErrorInfo members
        public event EventHandler<DataErrorsChangedEventArgs> ErrorsChanged;
        private void RaiseErrorsChanged(string propertyName) =>
            ErrorsChanged?.Invoke(this, new DataErrorsChangedEventArgs(propertyName));
        public System.Collections.IEnumerable GetErrors(string propertyName)
        {
            if (string.IsNullOrEmpty(propertyName)
                || !_validationErrors.ContainsKey(propertyName))
                return null;
            return _validationErrors[propertyName];
        }
        public bool HasErrors => _validationErrors.Count > 0;
        #endregion
    }
