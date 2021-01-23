    [MultiFieldRequired("AreaCode", "PhoneNumber", ErrorMessage="Please enter a phone number")]
    public class Customer
    {
        //...other fields here
    
        public string AreaCode { get; set; }
    
        public string PhoneNumber { get; set; }
    }
