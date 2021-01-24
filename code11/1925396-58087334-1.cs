      var grouped = banerData
        .GroupBy(d => d.Shop)
        .Select(g => new
        {
          Shop = g.Key,
          Cartoon = g.Select(i => i.Cartoon).Distinct().Count(),
          Box = g
            .GroupBy(i => i.Cartoon)
            .Select(gr => gr.Select(i => i.Box).Distinct().Count())
            .ToArray()
        }).ToList();
