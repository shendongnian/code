      List<Product> source = ...
      Product best = source
        .Aggregate(new List<Product>(), (s, a) => {
          if (s.Count <= 0 || s[0].Price == a.Price)
            s.Add(a);
          else if (a.Price <= s[0].Price) {
            s.Clear();
            s.Add(a);
          }
          return s;
        })
        .SingleOrDefault();
