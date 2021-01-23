    public void DoStuff(IEnumerable<Customer> customers)
    {
        foreach(var cust in from c in customers where c.LastName.StartsWith("Ro"))
        {
            Console.WriteLine(cust.CustomerId);
        }
    }
