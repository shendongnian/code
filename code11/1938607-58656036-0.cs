    public class PurchaseProduct
    {
        [Key, Column(Order = 0)]
        public string ProductsId { get; set; }
        [Key, Column(Order = 1)]
        public int PurchaseId { get; set; }
    }
