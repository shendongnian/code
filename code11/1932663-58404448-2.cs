    public Order CreateOrder(IEnumerable<OrderDetail> orderDetails)
    {
        using (var context = new AppContext())
        {
           var order = new Order();
           foreach(var orderDetail in orderDetails)
           {
               context.OrderDetails.Attach(orderDetail);
           }
           order.OrderDetails.AddRange(orderDetails);
           context.Orders.Add(order);
           context.SaveChanges();
           return order;
        }
    }
