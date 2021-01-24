    var model = await _dbContext.Orders.Select(o => new CustomDto
        {
          Id = o.Id,
          Name = o.Name,
          TotalPrice = _dbContext.OrderRows.Where(or => or.OrderId == o.Id).Sum(or => or.wkr.Price)
        }).ToListAsync();
