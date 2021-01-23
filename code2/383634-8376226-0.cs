    List<Order> myOrders = new List<Order>();
    var orders = xdoc.Descendants("Order").Select(x=> new Order{ 
        OrderNumber = x.Element("OrderNumber").Value,
        OrderDate = x.Element("OrderDate").Value,
        OrderTotal = x.Element("OrderTotal").Value
        });
    myOrders.AddRange(orders) // or just orders.ToList();
