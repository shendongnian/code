    public class Order
    {
        public List<OrderLine> OrderLines { get; set; }
    }
    public class OrderLine
    {
        // You could put a reference here back to the Order if you want...
    }
