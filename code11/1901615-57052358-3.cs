    [Table("AdditionalProduct")]
    public class AdditionalProduct
    {
        [Key]
        public int Id { get; set; }
    
        public int ProductId {get; set;}
        public int AdditionalProductId {get; set;}
    
        public Product Product {get; set;}
        public Product AdditionalProduct {get; set;}
    }
