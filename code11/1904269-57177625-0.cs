    public class Cart
    {
        public string accessToken { get; set; }
        public string requestId { get; set; }
        public string CreatedDate { get; set; }
        public Cartdetail CartDetail { get; set; }
    }
    public class Cartdetail
    {
        public string ProductId { get; set; }
        public string Qty { get; set; }
        public string Price { get; set; }
        public string CreatedDate { get; set; }
    }
