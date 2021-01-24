    IQuerayble<decimal> CalculateValueAddedTaxes(this IQueryable<Price> prices) {...}
    Order newOrder = new Order() {...};      // A local object
    newOrder.TotalVAT = newOrder.OrderLines  // A local sequence of OrderLInes
         .AsQueryable()                      // still Local, but now as IQueryable
         .CalculateValueAddedTaxex()         // so you can call this function
         .Sum();
