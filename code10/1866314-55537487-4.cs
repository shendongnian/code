    public class Address
    {
        public int AddressId { get; set; }
        public int ZipCodeId { get; set; }
        public string Street { get; set; }
        public int Nr { get; set; }
        
        public virtual ZipCode ZipCode { get; set; }
    }
