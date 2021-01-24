    query = _context.Customers
        .Include(x => x.CustomerStatus)
        .ThenInclude(x => x.StatusNavigation)
        .AsEnumerable()
        .Select(x => new Customers()
        {
            Id = x.Id,
            Address = x.Address,
            Contact = x.Contact,
            Name = x.Name,
            CustomerStatus = new List<CustomerStatus>
            {
                x.CustomerStatus.OrderByDescending(y => y.Date).FirstOrDefault()
            }
        })
        .FirstOrDefault(x => x.Id == 3);
