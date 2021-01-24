    public class OrderDetailModel
    {
        public int ID { get; set; }
        public int OrderID { get; set; }
        public int ItemID { get; set; }
    }
    
    public class RootObjectModel
    {
        public int ID { get; set; }
        public string Code { get; set; }
        public List<OrderDetailModel> OrderDetails { get; set; }
    }
