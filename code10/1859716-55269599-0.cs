    public class OrderProduct
    {
        [Key]
        public int Id { get; set; }
        public int OrderId {get;set;}
        [ForeignKey(nameof(OrderId))]
        public virtual Order Order { get; set; }
        public Product Product { get; set; }
        public int Quantity { get; set; }
    }
