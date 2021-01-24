    public class ReceiptProduct
    {
        public Guid Id { get; set; }
        public string ReceiptId { get; set; }
        public string PurchaseOrderId { get; set; }
        public string ProductName { get; set; }
        public string ProductId { get; set; }
        public string Note { get; set; }
        **public Receipt Receipt { get; set; }**
    }
