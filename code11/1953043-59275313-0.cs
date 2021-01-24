    public class SampleModel{
        public string UID { get; set; }    
        public string Email { get; set; }    
    
        [FromForm(Name = "first_name")]
        public string FirstName { get; set; }
        [FromForm(Name = "last_name")]
        public string LastName { get; set; }    
        public string Phone { get; set; }    
        public string City { get; set; }    
        [FromForm(Name = "state_code")]
        public string StateCode { get; set; }    
        public string Zip { get; set; }
    }
