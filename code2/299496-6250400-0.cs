    class Customer
    {
        private readonly Name name;
        private readonly PostalAddress homeAddress;
        public Customer(Name name, PostalAddress homeAddress, ...)
        {
            this.name = name;
            this.homeAddress = homeAddress;
            ...
        }
    }
    class CustomerFactory
    {
        Customer Create(CustomerDTO customerDTO)
        {
            return new Customer(new Name(...), new PostalAdress(...));
        }
    }
