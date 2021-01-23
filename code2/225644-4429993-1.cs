    public class Sale
    {
        [Column(Name="sale_id")]
        public int ID { get; set; }
        [Column(Name="product_name")]
        public string ProductName { get; set; }
        
        [Column(Name="product_price")]
        public string ProductPrice { get; set; }
        [Column(Name="sale_date")]
        public DateTime SaleDate { get; set; }
    }
