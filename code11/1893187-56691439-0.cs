    // find price of last item needed; worst case there won't be one
    var lastPriceItem = items.Select(i => new { i.Price, RT = items.Where(it => it.Price <= i.Price).Sum(it => it.Available) }).FirstOrDefault(irt => irt.RT > origReqVol);
    // bring over items below that price
    var orderedItems = items.OrderBy(i => i.Price).Where(i => i.Price <= lastPriceItem.Price).ToList();
    // compute running total on client
    var rtItems = orderedItems.Select(i => new {
        Item = i,
        RT = orderedItems.Where(i2 => i2.Price <= i.Price).Sum(i2 => i2.Available)
    });
    // computer average price
    var reqVol = origReqVol;
    var ans = rtItems.Select(irt => new { Price = irt.Item.Price, Quantity = Math.Min((reqVol -= irt.Item.Available)+irt.Item.Available, irt.Item.Available) })
                         .Sum(pq => pq.Price * pq.Quantity) / (double)origReqVol;
