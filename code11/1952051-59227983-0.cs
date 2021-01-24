    List<Order> orderList = new List<Order>(_context.Orders);
    List<OrderView> orderViewList = new List<OrderView>();  // Empty.
    foreach (Order order in orderList)
    {
        OrderView orderView = new OrderView;
        orderView.OrderNo = order.OrderNo;
        orderView.CustomerId = order.CustomerId;
        // ... etc
        orderViewList.Add(orderView);
    }
