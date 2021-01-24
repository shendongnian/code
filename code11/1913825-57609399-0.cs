    public class OrderDetail
    {
        public int ID { get; set; }
        public int OrderID { get; set; }
        public int ItemID { get; set; }
        [JsonIgnore]
        public double Quantity { get; set; }
        [JsonIgnore]
        public double ConfirmQuantity { get; set; }
        [JsonIgnore]
        public DateTime ConfirmDate { get; set; }
        [JsonIgnore]
        public DateTime Deadline { get; set; }
        [JsonIgnore]
        public bool IsCanceled { get; set; }
        [JsonIgnore]
        public int PersonnelID { get; set; }
        [JsonIgnore]
        public bool IsConfirmed { get; set; }
    }
    
    public class RootObject
    {
        public int ID { get; set; }
        public string Code { get; set; }
        [JsonIgnore]
        public int SupplierID { get; set; }
        [JsonIgnore]
        public DateTime Date { get; set; }
        public List<OrderDetail> OrderDetails { get; set; }
    }
