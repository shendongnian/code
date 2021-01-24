    from g in (from x in Data
              group x.Amount by new { x.Fund, x.Account } into g
              select new
              {
                g.Key.Fund,
                g.Key.Account,
                Amount = g.Sum()
              }).AsEnumerable()
    group new
    {
        g.Account,
        g.Amount,
    } by g.Fund;
