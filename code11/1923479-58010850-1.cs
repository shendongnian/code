    var result = from i in _context.Items
                 group i by i.IdItem into g
                 select new {
                      IdItem = g.Key,
                      Name = g.First().Name,
                      Quantity = g.Count(),
                      Available = g.Any(it => it.State.IdStatus == 1)
                 };
