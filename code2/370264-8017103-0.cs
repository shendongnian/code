    public class Customer
    {
        //...other fields here
    
        [MultiFieldRequired("AreaCode", "PhoneNumber", ErrorMessage="Please enter a phone number")]
        public string AreaCode { get; set; }
    
        [MultiFieldRequired("AreaCode", "PhoneNumber", ErrorMessage="Please enter a phone number")]
        public string PhoneNumber { get; set; }
    }
