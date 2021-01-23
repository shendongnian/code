    static void DoSomething(ICustomer customer)
    {
        //... code here ...
        InitializeCustomer(customer); 
        //... code here ...
    }
    static void InitializeCustomer(ICustomer c)
    {
        c.Reference = 1234;
        c.Name = "John";
    }
