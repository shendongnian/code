    var results = items
      .GroupBy(i => new { i.Date, i.CustomerID })
      .Select(g => new {
        CustomerID = g.Key.CustomerID,
        Date = g.Key.Date,
        Item = string.Join(", ", g.Select(i => i.Item).ToArray())
      });
