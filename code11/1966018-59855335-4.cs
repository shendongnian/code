      using System.Linq;
      ...
      List<Product> source = ...
      var bests = source
        .Aggregate(new List<Product>(), (s, a) => {
          if (s.Count <= 0 || s[0].Price == a.Price)
            s.Add(a);
          else if (a.Price <= s[0].Price) {
            s.Clear();
            s.Add(a);
          }
          return s;
        });
      Product best = bests.Count == 1 ? bests[1] : default(Product);
