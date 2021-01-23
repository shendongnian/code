    Component.For<IOrder>()
         .Named("order.service")
         .ImplementedBy<Order>()
        .ActAs(new RestServiceModel()
         {
          Endpoints = new IWcfEndpoint[] { WcfEndpoint.BoundTo(new WebHttpBinding() { TransferMode=TransferMode.Streamed, MaxBufferSize=int.MaxValue,MaxReceivedMessageSize=long.MaxValue }).At(OrderUrlBase) }
         })
