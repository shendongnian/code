    public class User
    {
        [Required(ErrorMessage = "Your first name is required.")]
        public string FirstName { get; set; }
        [Required(ErrorMessage = "Your last name is required.")]
        public string LastName { get; set; }        
        
        [Required(ErrorMessage = "A logon name is required.")]
        public string Logon { get; set; }
        [Required(ErrorMessage = "A password is required.")]
        public string Password { get; set; }
        [Required(ErrorMessage = "A role is required.")]
        public string Role { get; set; }
        [Required(ErrorMessage = "An airport is required.")]
        public Airport Airport { get; set; }
        [DisplayName("Is Active")]
        bool IsActive { get; set; }
    }
