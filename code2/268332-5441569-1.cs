    public class Category
    {
        [Key, Column(Order = 0)]
        public int CategoryId2 { get; set; }
        [Key, Column(Order = 1)]
        public int CategoryId3 { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        public string Name { get; set; }
        [ForeignKey("Category"), Column(Order = 0)]
        public int CategoryId2 { get; set; }
        [ForeignKey("Category"), Column(Order = 1)]
        public int CategoryId3 { get; set; }
        public virtual Category Category { get; set; }
    }
