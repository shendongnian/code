    // Should be Ok...
    var product = await context.Products.SingleAsync(x => x.ProductId == productId);
    var customer = await context.Customers.SingleAsync(x => x.CustomerId == customerId);
    var newOrder = new Order { Product = product, Customer = customer};
     
    // Not Ok...
    var productGet = context.Products.SingleAsync(x => x.ProductId == productId);
    var customerGet = context.Customers.SingleAsync(x => x.CustomerId == customerId);
    var newOrder = new Order { Product = await productGet, Customer = await customerGet};
