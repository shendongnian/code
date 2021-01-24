    // OrderView constructor
    public OrderView(Order order)
    {
        this.OrderNo = order.OrderNo;
    }
    // Linq to create new list
    List<OrderView> orderView = orders.Select(o => new OrderView(o));
