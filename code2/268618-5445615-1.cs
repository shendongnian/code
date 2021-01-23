    var product = context.Products.Single(p => p.Id == productId);
    var order = new Order
      {
        CustomerId = customerId,
        OrderLineItems = new List<OrderLineItme>
          {
            new OrderLineItem
              {
                Product = product
              }
          }
      };
