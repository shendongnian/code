[ForeignKey("CategoryId1, CategoryId2")]
    public class Category
    {
        [Key, Column(Order = 0)]
        public int CategoryId1 { get; set; }
        [Key, Column(Order = 1)]
        public int CategoryId2 { get; set; }
        public string Name { get; set; }
    
        public virtual ICollection<Product> Products { get; set; }
    }
    
    public class Product
    {
        [Key]
        public int ProductId { get; set; }
        public string Name { get; set; }
        public int CategoryId1 { get; set; }
        public int CategoryId2 { get; set; }
    
        [ForeignKey("CategoryId1, CategoryId2")]
        public virtual Category Category { get; set; }
    }
