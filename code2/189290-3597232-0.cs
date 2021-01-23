    var products = new[] {
      new { Id = 1, Name = "Alpha", Color = "Red" },
      new { Id = 2, Name = "Beta", Color = "Green" },
      new { Id = 3, Name = "Gamma", Color = "Blue" }
    };
    var costs = new[] {
      new { Color = "Red", Cost = 100 },
      new { Color = "Blue", Cost = 200 },
      new { Color = "Blue", Cost = 300 }
    };
    var query = products
      .GroupJoin(
        costs, p => p.Color, c => c.Color,
        (p, c) => new { p.Id, p.Name, p.Color, Costs = c.DefaultIfEmpty() }
      )
      .SelectMany(
        gj => gj.Costs,
        (gj, c) => new { gj.Id, gj.Name, gj.Color, Cost = c == null ? 0 : c.Cost }
      );
