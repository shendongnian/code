    badquery = work.GetRepository<Customer>().Table
      .GroupBy(c => c.Orders.Count())
      .Select(g => new
      {
        TheCount = g.Key,
        TheCustomers = g.ToList()
      }).ToArray();
    goodquery = work.GetRepository<Customer>().Table
      .Select(c => new {Customer = c, theCount = c.Orders.Count())
      .ToArray()
      .GroupBy(x => x.theCount)
      .Select(g => new
      {
        TheCount = g.Key,
        TheCustomers = g.Select(x => x.Customer).ToList()
      })
      .ToArray();
