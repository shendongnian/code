    public class Address
    {
        public string Address1 { get; set; }
        public string Address2 { get; set; }
    }
    public class UserAddress
    {
        public User User { get; set; }
        public Address Address { get; set; }
        public UserAddress()
        {
            User = new User();
            Address = new Address();
        }
    }
