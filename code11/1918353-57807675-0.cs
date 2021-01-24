    await _dbContext.Holidays
        .GroupBy(h => new { h.Date, h.Username})
        .Select(g => new
            {
              g.Key.Date,
              g.Key.Username
            });
