    public class ConfirmPassword 
    {
        User model;
        [Required]
        public string Username 
        { 
            get { return this.model.Username; } 
            set { this.model.Username = value; } 
        }
        [Required]
        [DataType(DataType.Password)]
        public string Password 
        { 
            get { return this.model.Pwd; } 
            set { this.model.Pwd = value; } 
        }
        
        [Required(ErrorMessage = "Confirm Password field is required.")]
        [Compare("NewPassword", 
           ErrorMessage = "The new password and confirmation password do not match.")]
        [RegularExpression(@"^.{8,10}$")]
        [DataType(DataType.Password)]
        public string ConfirmPwd { get; set; }
        public ConfirmPassword()
        {
            this.model = new User();
        }
        public ConfirmPassword(User model)
        {
            this.model = model;
        }
    }
