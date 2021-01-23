    var query = _context.Customer
      .Where(c => c.Orders.Any(o => o.DateSent == null))
      .Select(c => new CustomerSummary
      {
        Id = c.Id,
        Username = c.Username,
        OutstandingOrderCount = c.Orders.Count(o => o.DateSent == null)
      };
