    public class YourClass {
        public string name { get; set; }
        public int age { get; set; }
        public List<long> phone { get; set; }
        public List<Address> address { get; set; }   
    }
    public class Address {
        public string address1 { get; set; }
        public string address2 { get; set; }
        public string addressLine1 { get; set; }
        public string addressLine2 { get; set; }
        public AdditionalInformation additionalInfo { get; set; }
    }
    public class AdditionalInformation {
        public int pin { get; set; }
        public string landmark { get; set; }
    }
