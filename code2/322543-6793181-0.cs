    public Customer GetCustomer(int id)
    {
         return connection.Query("getCustomer",
             new {id}, // <=== param
             commandType: CommandType.StoredProcedure).Single();
    }
