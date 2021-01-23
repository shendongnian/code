    var order = new Order
      {
        CustomerId = customerId,
        OrderLineItems = new List<OrderLineItme>
          {
            new OrderLineItem
              {
                ProductId = productId
              }
          }
      };
