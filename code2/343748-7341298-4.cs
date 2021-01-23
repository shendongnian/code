    CustomerList customerList = new CustomerList 
    { 
        new Customer
        {
            FirstName = "John",
            LastName = "Doe",
            Email = "johndoe@foobar.com",
            CustomerId = "123"
        },
        new Customer
        {
            FirstName = "Jane",
            LastName = "Doe",
            Email = "janedoe@foobar.com",
            CustomerId = "456"
        }
    };
    
    SerializeCustomerList(CustomerList customers)
    {
        //TODO: Serialize CustomerList instance...
    }
