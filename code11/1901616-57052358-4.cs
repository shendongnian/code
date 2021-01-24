    [Table("Product")]
    public class Product : EntityBase
    {
        [Key]
        public int Id { get; set; }
    
        .......
    
        public virtual ICollection<AdditionalProduct> HisAdditionalProducts { get; set; }
        public virtual ICollection<AdditionalProduct> AdditionalProductsTo { get; set; }
    }
