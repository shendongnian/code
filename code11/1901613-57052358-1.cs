    [Table("Product")]
    public class Product : EntityBase
    {
        [Key]
        public int Id { get; set; }
    
        .......
    
        public virtual ICollection<Product> HisAdditionalProducts { get; set; }
        public virtual ICollection<Product> AdditionalProductsTo { get; set; }
    }
