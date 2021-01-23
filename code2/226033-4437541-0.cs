    public class OrderItem {
        public int OrderItemID { get; set; }
        public int OrderID { get; set; }
        public int Quantity { get; set; }
        public int ItemID { get; set; }
    }
    public class Item : OrderItem {
        // public int ItemID { get; set; } not anymore needed
        public string Name { get; set; }
        public string Description { get; set; }
        public int Size { get; set; }
    }
