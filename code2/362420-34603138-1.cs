    public static Customer GetCustomer (int custid)
    {
    Customer co = null;
    
    using (var context = new YourEntities())
    {
        // your code
        co =  context.Customer.SqlQuery(
        @"select [Customer].[CustomerId], 
        ...
        [Order].[OrderId] AS [OrderId], 
        ...
        from Customer join Order on Customer.CustomerId = Order.CustomerId where Customer.CustomerId = @custid", sqlParm)
        .FirstOrDefault();
    
    
        // my addition
        // cause lazy loading of Orders before closing the using
        ICollection<Order> orders = co.Orders;
        }
    
        // can access co.Orders after return.
        return (co);
    }
