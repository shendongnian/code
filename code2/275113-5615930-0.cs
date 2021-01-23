    class NameAndEmail
    {
        [Required(ErrorMessage = "Name is a required field.")]
        [StringLength(100, ErrorMessage = "Name must be 100 characters or less.")]
        public string Name { get; set; }
        
        [Required(ErrorMessage = "Email address is a required field.")]
        [Email(ErrorMessage = "Email address must be a valid format.")]
        [StringLength(100, ErrorMessage = "Email address must be 100 characters or less.")]
        [DisplayName("Email address")]
        public string Email { get; set; }
    }
    class SsUserMetaData : NameAndEmail
    {
        [Required(ErrorMessage = "Username is a required field.")]
        [StringLength(50, ErrorMessage = "Username must be 50 characters or less.")]
        public string Username { get; set; }
        
       
        [Required(ErrorMessage = "Password is a required field.")]
        [StringLength(1000, MinimumLength = 6, ErrorMessage = "Passwords must be at least 6 characters long.")]
        [DisplayName("Password")]
        public string PasswordHash { get; set; }
    }
