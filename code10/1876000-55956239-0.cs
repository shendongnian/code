    public static List<Customer> GetAllQBOCustomers(ServiceContext context)
    {
        var list = new List<Customer>();
        for (int i=0; i<=10000; i+= 1000)
        {
            var results = Helper.FindAll<Customer>(context, new Customer(),i, 1000);
            list.AddRange(results);
        }
        return list;
    }
