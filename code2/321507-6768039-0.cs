    var q = db.Customers.GroupJoin(db.Orders,
                                   o => o.CustomerID,
                                   c => c.CustomerID,
                                   (c, orders) =>
                                       new
                                       {
                                           c.ContactName, 
                                           OrderCount = orders.Count()
                                       });
