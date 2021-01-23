    [PropertiesMustMatch("Password", "RetypePassword", 
      ErrorMessage = "The password and confirmation password do not match.")]
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
       public string RetypePassword { get; set; }
    
       //...
    }
