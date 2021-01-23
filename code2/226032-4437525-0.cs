    public class OrderItem {
        public int OrderItemID { get; set; }
        public int OrderID { get; set; }
        public int Quantity { get; set; }
        public virtual Item Item { get; set; }
    }
