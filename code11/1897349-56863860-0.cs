    _db.InvoiceItem.Where(i => i.Unit == "Hour" && i.Category != null)
                          .GroupBy(i => i.Category)
                          .Select(i => new
                          {
                              Category = i.Key.Category,
                              Quantity = i.Sum(s => s.Quantity * s.Price)
                          })               
                          .OrderByDescending(i => i.Quantity)
                          .Take(10);
