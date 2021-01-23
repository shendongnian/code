    public class CustomerRepository
    {
		...
		
        /// <summary>Raised when a customer is placed into the repository.</summary>
        public event EventHandler<CustomerAddedEventArgs> CustomerAdded;
        /// <summary>
        /// Places the specified customer into the repository.
        /// If the customer is already in the repository, an
        /// exception is not thrown.
        /// </summary>
        public void AddCustomer(Customer customer)
        {
            if (customer == null) throw new ArgumentNullException("customer");
            if (_customers.Contains(customer)) return;
            _customers.Add(customer);
            if (CustomerAdded != null)
                CustomerAdded(this, new CustomerAddedEventArgs(customer));
        }
		
		...
    }
