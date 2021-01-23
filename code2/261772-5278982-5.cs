    using (var context = new MyContextType())
    {
        var Customers = context.Customers.ToList(); // ToList triggers the query
        var query = from d in Customers
                    select d;
    
        if (!flag)
        {
           query = from d in query
                   where d.Orders.Count > 10
                   select d;
        }
        return query.ToList();
    }
