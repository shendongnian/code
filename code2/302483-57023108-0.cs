    using System.ComponentModel.DataAnnotations.Schema;
    
    [Table("Product", Schema="Production")]
    public class Product
    {
        public int ProductID { get; set; }
        public decimal Price { get; set; }
    }
