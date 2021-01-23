    IQueryable<Customer> lists = customerPersister.Query().Where(item => item.Id == id);
    if (needLinesOfBusiness)
        lists = lists.FetchMany(item => item.LineOfBusiness);
    if (needAddress)
        lists = lists.FetchMany(item => item.Address);
    if (needOrders || needOrderItems)
    {
        if (!needOrderItems)
            lists = lists.FetchMany(item => item.Orders);
        else
            lists = lists.FetchMany(item => item.Orders).ThenFetchMany(order => order.Items);
    }
