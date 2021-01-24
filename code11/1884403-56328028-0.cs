    [SQLite.PrimaryKey, SQLite.AutoIncrement]
    public class StockTransferArgs
    {
        [SQLite.PrimaryKey, SQLite.AutoIncrement]
        public int StockTransferArgsId { get; set; }
        public long StockItemID { get; set; }
        public string Code { get; set; }
        public string OperationName { get; set; }
        public string Description { get; set; }
        public decimal Quantity { get; set; }
        public long SourceWarehouseID { get; set; }
        public string SourceBinName { get; set; }
        public long TargetWarehouseID { get; set; }
        public string TargetBinName { get; set; }
        public string Reference { get; set; }
        public string SecondReference { get; set; }
        public string BarCode { get; set; }
        public int Status { get; set; }
    }
