    foreach (item in resultset)
    {
    
      if (item is customer)
      {
         CustomerDictionary.Add(item.id, item)
      }
    
      if (item is order)
      {
         OrderDictionary.Add(item.id, item)
         GetCustomer(item.parent).AddOrder(item)
      }
    
      if (item is orderitem)
      {
         GetOrder(item.parent).AddOrderItem(item)
      }
    }
