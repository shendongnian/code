    [Table("AdditionalProducts")]
    public class AdditionalProduct
    {
        [Key]
        public int Id { get; set; }
        public virtual ICollection<Product> AdditionalProducts { get; set; }
    }
