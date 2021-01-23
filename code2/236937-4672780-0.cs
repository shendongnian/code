    public Customer InitializeCustomer (dynamic reader)
    {
        Customer customer = new Customer();
        // Automatically calls the [1] indexer for whatever class reader is
        customer.CompanyName = reader[1].ToString();
        // ...
        return Customer;
    }
