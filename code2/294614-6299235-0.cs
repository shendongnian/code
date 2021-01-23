    List<OrderHistory> orderHistories;
    var session = GetSession(); // Gets the active session for the request
    var repository = new OrderHistory(Repository);
    // new up more repositories as needed, they will all participate in the same transaction
    using (var txn = session.BeginTransaction())
    {
        // use try..catch block if desired
        orderHistories = repository.GetOrderHistories();
        txn.Commit();
    }
