    public static List<Customer> GetAllQBOCustomers(ServiceContext context)
    {
        var bag = new ConcurrentBag<Customer>();
        Parallel.ForEach( Enumerable.Range(0, 10), i =>
        {
            var results = Helper.FindAll<Customer>(context, new Customer(),i * 1000, 1000);
            bag.AddRange(results);
        });
        return bag.ToList();
    }
