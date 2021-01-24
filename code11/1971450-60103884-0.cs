    public void Map()
    {
        var products = new List<Product>()
        {
            new Product {Id = "1", Group = "1"},
            new Product {Id = "1", Group = "2"},
            new Product {Id = "1", Group = "3"},
            new Product {Id = "2", Group = "1"},
            new Product {Id = "2", Group = "2"},
            new Product {Id = "2", Group = "3"}
        };
        products.GroupBy(p => p.Id).Select(grp =>
        {
            var pById = new ProductById()
            {
                Id = grp.Key
            };
            pById.Group1 = grp.First(g => g.Group == "1").Group;
            pById.Group2 = grp.First(g => g.Group == "2").Group;
            pById.Group3 = grp.First(g => g.Group == "3").Group;
            return pById;
        });
    }
