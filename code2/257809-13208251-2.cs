    public class Product
        {
            public Product() { Id = Guid.NewGuid(); Created = DateTime.Now; }
            public Guid Id { get; set; }
            public string ProductName { get; set; }
        }
