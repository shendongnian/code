    [AtLeastOneRequired("Tel1", "Tel2", ErrorMessage="Please enter at least one value.")]
    public class PhoneNumber { 
     
        public long Id { get; set; } 
        public string Tel1 { get; set; } 
        public string Tel2 { get; set; } 
    } 
