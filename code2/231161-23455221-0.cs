    using (var context = new NorthwindEntities())
    {
        DateTime volumn1Date = DateTime.Today.AddDays(-1);
        DateTime volumn7Date = DateTime.Today.AddDays(-7);
        DateTime volumn30Date = DateTime.Today.AddDays(-30);
    
    var query = from o in context.Order_Details
                    group o by o.Product.ProductName into g
                    select new
                    {
                        ProductName = g.Key,
                        Volume1Day = g.Sum(d => d.Order.OrderDate.Value <= volumn1Date ? (Int32?) d.Quantity : 0),
                        Volume7Day = g.Sum(d => d.Order.OrderDate.Value <= volumn7Date ? (Int32?) d.Quantity : 0),
                        Volume30Day = g.Sum(d => d.Order.OrderDate.Value <= volumn30Date ? (Int32?) d.Quantity : 0)
                    };
    
        var list = query.ToList();
    }
