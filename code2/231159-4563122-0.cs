        using (var context = new NorthwindEntities()) {
            DateTime volumn1Date = DateTime.Today.AddDays(-1);
            DateTime volumn7Date = DateTime.Today.AddDays(-7);
            DateTime volumn30Date = DateTime.Today.AddDays(-30);
            var query = from o in context.Order_Details
                        group o by o.Product.ProductName into g
                        select new
                        {
                            ProductName = g.Key,
                            Volume1Day = g.Where(d => d.Order.OrderDate.Value <= volumn1Date)
                                          // cast to Int32? because if no records are found the result will be a null                                              
                                           .Sum(d => (Int32?) d.Quantity),
                            Volume7Day = g.Where(d => d.Order.OrderDate.Value <= volumn7Date)
                                          .Sum(d => (Int32?) d.Quantity),
                            Volume30Day = g.Where(d => d.Order.OrderDate.Value <= volumn30Date)
                                           .Sum(d => (Int32?) d.Quantity)
                        };
            
            var list = query.ToList();
        }
