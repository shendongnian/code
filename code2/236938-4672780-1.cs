    public static Customer FromReader(dynamic reader)
    {
        Customer customer = new Customer();
        // Automatically calls the [1] indexer for whatever class reader is
        customer.CompanyName = reader[1].ToString();
        // ...
        return Customer;
    }
    [...]
    var customer = Customer.FromReader(myDbReader);
