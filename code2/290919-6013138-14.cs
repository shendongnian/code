    // This has no methods or getters, so gets a good cohesion value.
    class CustomerData
    {
        public string FullName;
        public Address PostalAddress;
    }
    // All of the getters and methods are on the same object
    class Customer
    {
       private CustomerData _customerData;
       public string FullName { get { return _customerData.FullName; } }
       // etc
    }
