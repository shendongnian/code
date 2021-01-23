        var products = from prod in (/* first query */).AsEnumerable()
                       select new Product {
                            ID = p.ID,
                            Description = p.Description,
                            ....
                            Cost = pd.Cost.HasValue ? pd.Cost : p.Cost,
                            Price = pd.Price.HasValue ? pd.Price : p.Price,
                            ...
                       };
