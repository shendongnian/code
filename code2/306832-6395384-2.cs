    var query = context.Customers
                       .Select(c => new {
                            Customer = c,
                            Purchases = c.Purchases.OrderByDescending(p => p.Date).Take(5)
                        });
