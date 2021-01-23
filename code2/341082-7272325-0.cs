    public abstract class Product
    {
        [Key]
        public Guid Guid { get; set; }
    
        [Required]
        public String Title { get; set; }
    
        public ProductType Type { get; set; }
    }
