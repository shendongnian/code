    var result = Orders
        .Join(Assigns, o => o.OrderId, a => a.OrderId, (o, a) => new {Order = o, Assign = a})
        .GroupBy(o => o.Order.ExpectedDeliveryDate.Date)
        .Select(g => new
        {
            Date = g.Key,
            OnTime = g.Count(o => o.Assign.DeliveryDate <= o.Order.ExpectedDeliveryDate),
            Delayed = g.Count(o => o.Assign.DeliveryDate > o.Order.ExpectedDeliveryDate)
        })
        .ToArray();
