    public class AspNetUser : IdentityUser<string> 
    {
        public DateTime RegistrationTime { get; set; }
        public string OtherPros {get;set;},
    }
