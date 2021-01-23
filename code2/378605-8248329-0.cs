    public class Address
    {
        public AddressType AddressType { get; set; }
        public string Street { get; set; }
        // etc...
    }
    public enum AddressType
    {
        Business,
        Home,
        Other,
        PostOfficBox,
    }
