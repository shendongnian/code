    public async Task Consume (ConsumeContext<CreateOrder> context) {
      try {
        var order = new Order ();
        var product = store.GetProduct (command.ProductId); // check if requested product exists
        if (product is null) {
          throw new DomainException (OperationCodes.ProductNotExist);
        }
        order.AddProduct (product);
        store.SaveOrder (order);
        context.Publish<OrderCreated> (new OrderCreated {
          OrderId = order.Id;
        });
      } catch (DomainException exception) {
        await context.Publish<CreateOrderRejected> (new CreateOrderRejected {
          ErrorCode = domainException.Code;
        });
      }
    }
