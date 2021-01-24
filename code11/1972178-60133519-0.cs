    public class Customer
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [DataType("Address")]
        public Addresss Address { get; set; }
    }
    public class Addresss
    {
        public string FirstLine { get; set; }
        public string SecondLine { get; set; }
    }
