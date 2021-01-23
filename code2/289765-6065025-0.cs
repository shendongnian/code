    Query query = new Query
    {
      Order = Order.By(Entity.Attribute("Number")
                             .Function("CAST", new LiteralExpression("INTEGER") { EmitInline = true }))
    };
    
    uow.Find<RfidTag>(query);
