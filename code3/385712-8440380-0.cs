    using (DataClasses1DataContext context = new DataClasses1DataContext())
    {
        Customer customer = context.Customers.Where(x => x.CustomerID == 1).Single();
        Order order = new Order();
        // set some order fields here
        customer.Orders.Add(order);
        OrderDetail orderDetail = new OrderDetail();
        order.OrderDetails.Add(orderDetail);
        orderDetail.Product = context.Products.Where(x => x.ProductID == 2).Single();
        orderDetail.ProductID = orderDetail.Product.ProductID;
        context.SubmitChanges();
    }
