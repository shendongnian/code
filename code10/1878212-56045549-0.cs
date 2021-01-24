    public class EmailAddresses
    {
        public List<string> emailAddress { get; set; }
    }
    
    public class CustPhoneNumbers
    {
        public List<string> custPhoneNumber { get; set; }
    }
    
    public class Customer
    {
        public EmailAddresses emailAddresses { get; set; }
        public CustPhoneNumbers custPhoneNumbers { get; set; }
        public string custIDString { get; set; }
    }
    
    public class RootObject
    {
        public List<Customer> customer { get; set; }
    }
