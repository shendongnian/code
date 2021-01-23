    public class Order
    {
        public int Id { get; set; }
        public string OrderNumber { get; set; }
        public decimal Balance { get; set; }
        public DateTime Opened { get; set; }
        public bool IsActive { get; set; }
        public List<string> Items { get; set; }
    }
