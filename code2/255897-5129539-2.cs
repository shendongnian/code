    private static Expression<Func<Northwind_LINQtoSQLDataContext,
                                   IQueryable<Customer>>
        GetPreCompiledQuery()
    {
        return db => db.Customers.Where(cust => cust.Country == "Germany");
    }
