    public Order CreateOrder(IEnumerable<int> orderDetailIds)
    {
        using (var context = new AppContext())
        {
           var order = new Order();
           var orderDetails = context.OrderDetails.Where(x => orderDetailIds.Contains(x.OrderDetailId)).ToList();
           order.OrderDetails.AddRange(orderDetails);
           context.Orders.Add(order);
           context.SaveChanges();
           return order;
        }
    }
