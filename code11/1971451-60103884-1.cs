    public class ProductById
    {
        public string Id { get; set; }
        public IEnumerable<string> Groups { get; set; }
    }
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
                Id = grp.Key,
                Groups = grp.Select(g => g.Group).ToList()
            };
            return pById;
        });
    }
