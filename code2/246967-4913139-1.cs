    DateTime inputDate = ...;
    var result = transactions
              .Where(t => t.TransDateTime.Date <= inputDate.Date)
              .GroupBy(t => new {t.ProductId, t.WarehouseId})
              .Select(x => new {
                   x.Key,
                   LastTransaction = x.OrderByDescending(t => t.TransDateTime).First(),
              })
              .Select(x => new {
                   Id = x.LastTransaction.Id,
                   Date = x.LastTransaction.TransDateTime,
                   ProductId = x.Key.ProductId,
                   WarehouseId = x.Key.WarehouseId,
                   Balance = x.LastTransaction.Balance,
              });
