    public class RequestData
    {
        public int ProductStockDetailsID { get; set; }
        public int LocationID { get; set; }
        public int ProductID { get; set; }
        public object MinStock { get; set; }
        public object MaxStock { get; set; }
        public int OnOrder { get; set; }
        public bool Alerts { get; set; }
        public Productstock[] ProductStocks { get; set; }
    }
    public class Productstock
    {
        public int StockID { get; set; }
        public int CurrentStock { get; set; }
        public int CurrentVolume { get; set; }
        public DateTime CreatedDate { get; set; }
        public object DeletedDate { get; set; }
        public float CostPrice { get; set; }
        public int ProductStockDetailsID { get; set; }
    }
