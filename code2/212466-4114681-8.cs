    public class SignUpViewModel
    {
        [Required]
        [StringLength(100)]
        public string Username { get; set; }
        [Required]
        [Password]
        public string Password { get; set; }
        [Required]
        [DisplayText("RetypePassword")]
        [Compare("Password")] // the RetypePassword property must match the Password field in order to be valid.
        public string RetypePassword { get; set; }
        // ...
    }
