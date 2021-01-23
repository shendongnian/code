    foreach (item in resultset)
    {
      // Build a customer and order dictionary
      if (!CustomerDictionary.Contains(item.Customer.Id)
         CustomerDictionary.Add(item.Customer.Id, item.Customer)
      if (!OrderDictionary.Contains(item.Order.Id)
         OrderDictionary.Add(item.Order.id, item.Order)
      // Now add the association      
      var customer = CustomerDictinoary[item.Customer.Id];
      customer.AddOrder(item.Order);
      var order = OrderDictinoary[item.Order.id];
      order.AddOrderItem(item.OrderItem);
    }
