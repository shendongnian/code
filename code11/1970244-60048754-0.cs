    public class Supplier : ModelBase
    {
        public string CompanyName { get; set; }
        public string ContactPerson { get; set; }
        public string Phone { get; set; }
        public string Street { get; set; }
        public string Zip { get; set; }
        public string City { get; set; }
        public int Discount { get; set; }
        public ICollection<SalesOrder> SalesOrders { get; set; }
    }
