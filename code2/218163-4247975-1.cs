    List<Customer> customers = new List<Customer>();
    using (DbDataReader reader = // instantiate reader)
    {
        while (reader.Read())
        {
           Customer customer = new Customer(reader.GetInt32(0), reader.GetString(1));
           customers.Add(customer);
        }
    }
