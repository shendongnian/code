    public class Invoice
    {
        public string PartCode { get; set; }
        public int Quantity { get; set; }
        public decimal UnitPrice { get; set; }
        public Invoice(string part, decimal price)
        {
            PartCode = part;
            UnitPrice = price;
        }
        public void DisplayOrder(int quantity, decimal price, string part)
        {
            // Do something using the above parameters
        }
    }
