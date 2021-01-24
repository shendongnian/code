            using (var context = new TestDbContext())
            {
                var ids = await context.Customers.Select(x => x.CustomerId).ToListAsync();
                foreach (var id in ids)
                {
                    var orders = await context.Orders.Where(x => x.CustomerId == id).ToListAsync();
                    // do stuff with orders.
                }
            }
