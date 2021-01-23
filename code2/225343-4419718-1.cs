        var products = /* most of second query */
                       select new { // <==== not a Product
                            ID = p.ID,
                            Description = p.Description,
                            ....
                            Cost = pd.Cost.HasValue ? pd.Cost : p.Cost,
                            Price = pd.Price.HasValue ? pd.Price : p.Price,
                            ...
                       };
