    public Order CreateOrder(IEnumerable<OrderDetail> orderDetails)
    {
        using (var context = new AppContext())
        {
           var order = new Order();
           order.OrderDetails.AddRange(orderDetails);
           context.Orders.Add(order);
           context.SaveChanges();
           return order;
        }
    }
