    [Table("Product")]
    public class Product
    {
        [Key]
        public int Id { get; set; }
        public virtual ICollection<Argument> Arguments { get; set; }//your business
        public int AdditionalProductsId { get; set; }
        public virtual AdditionalProduct AdditionalProducts { get; set; }
    }
