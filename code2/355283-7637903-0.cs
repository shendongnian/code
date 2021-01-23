    var orders = Context.Orders
        .Select(o => new
        {
            Order = o,
            SubOrderBases = o.SubOrderBases.Where(s => !(s is MyOrder)),
            MyOrdersWithCustomers = o.SubOrderBases.OfType<MyOrder>()
                .Select(m => new
                {
                    MyOrder = m,
                    Customers = m.Customers
                })
        })
        .ToList()  // <- query is executed here, the rest happens in memory
        .Select(a => 
        {
            a.Order.SubOrderBases = new List<SubOrderBase>(
                a.SubOrderBases.Concat(
                a.MyOrdersWithCustomers.Select(m => 
                    {
                        m.MyOrder.Customers = m.Customers;
                        return m.MyOrder;
                    })));
            return a.Order;
        })
        .ToList();
