    var CustomerResults = ctx.Customers 
                             .Select(x => new
                             {
                                Customer = x,
                                Orders = x.Orders.Where(y => y.DateTimeIn > value)
                             }).ToList();
