	var backOrdered = partList.GroupBy(p => new { p.OrderId, p.OrderTotal })
	.Select(g => new
	{
		g.Key.OrderId,
		g.Key.OrderTotal,
		TotalShipped = g.Sum(pi => pi.ShippedQty)
	})
	.Where(x => x.TotalShipped  < x.OrderTotal);
