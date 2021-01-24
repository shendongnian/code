    var data = context.Customer
                        .GroupJoin(context.Orders, c=> c.Id, o => o.CustoerId, (c, o) => new
                        {
                            customer = c,
                            orders= o
                        })
                        .ToList()
                        .Select(s => new
                        {
                            s.customer.Name,
                            s.customer.Id
                            AllOrdersRef = s.orders == null ? null : string.Join(", ", s.orders.Select(x => x.UniquRef))
                        });
