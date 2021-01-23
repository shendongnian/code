    public class Category
    {
        public string CategoryId { get; set; }
        public string Name { get; set; }
        public virtual ICollection<Product> Products { get; set; }
    }
    public class Product
    {
        public int ProductId { get; set; }
        public string Name { get; set; }
        [Required]
        public string CategoryId { get; set; }
        public virtual Category Category { get; set; }
    }
