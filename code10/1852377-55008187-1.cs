    public class Customer
    {
        public Guid Id { get; set; }
        public string Code { get; set; }
        public string Name { get; set; }
        public string VatCode { get; set; }
        public string ChamberOfCommerceCode { get; set; }
        public DateTime Modified { get; set; }
        public DateTime Created { get; set; }
        public string LanguageCode { get; set; }
        public decimal Discount { get; set; }
        public string CustomerManager { get; set; }
        public Guid PriceList { get; set; }
        public Guid PaymentCondition { get; set; }
        public bool IsBlocked { get; set; }
        public bool IsProspect { get; set; }
        public bool IsSuspect { get; set; }
        public string Website { get; set; }
        public string DashboardUrl { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Fax { get; set; }
        public ICollection<FreeFields> FreeFields { get; set; }
        public ICollection<Contact> Contacts { get; set; }
        public ICollection<Address> Addresses { get; set; }
    }
