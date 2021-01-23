    public Customer GetCustomer(int id)
    {
         return connection.Query<Customer>("getCustomer",
             new {id}, // <=== param
             commandType: CommandType.StoredProcedure).Single();
    }
