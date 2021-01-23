            var query =
                _context.Customers.SelectMany(c => c.Orders, (c, o) => new {c, o}).Where(@t => o.DateSent == null)
                    .Select(@t => new CustomerSummary
                                     {
                                         Id = c.Id,
                                         Username = c.Username,
                                         OutstandingOrderCount = c.Orders.Count
                                     });
