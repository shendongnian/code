    public class User
    {
        public int Id { get; set; }
        public string Name { get; set; }
        
        [ForeignKey("Address")]
        public int? AddressId { get; set; }
        public Address Address { get; set; }
    }
    public class Address
    {
        public int Id { get; set; }
        public string AddressName { get; set; }
        public string Municipality { get; set; }
    }
