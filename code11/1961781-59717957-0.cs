    public class SomeViewModel
    {
        [Display(Name = "Address", ResourceType = typeof(DisplayNameResource))]
        [Required(ErrorMessageResourceName = "RequiredError", ErrorMessageResourceType = typeof(ErrorMessageResource))]
        [StringLength(256, ErrorMessageResourceName = "MaxLengthError", ErrorMessageResourceType = typeof(ErrorMessageResource))]
        public string Address { get; set; }
    
        [Display(Name = "Phone", ResourceType = typeof(DisplayNameResource))]
        [Required(ErrorMessageResourceName = "RequiredError", ErrorMessageResourceType = typeof(ErrorMessageResource))]
        [RegularExpression("^09([0-9]{9})$", ErrorMessageResourceName = "PhoneLengthError", ErrorMessageResourceType = typeof(ErrorMessageResource))]
        public string Phone { get; set; }
    
        [Display(Name = "Password", ResourceType = typeof(DisplayNameResource))]
        [Required(ErrorMessageResourceName = "RequiredError", ErrorMessageResourceType = typeof(ErrorMessageResource))]
        [StringLength(50, MinimumLength = 6, ErrorMessageResourceType = typeof(ErrorMessageResource), ErrorMessageResourceName = "MinxMaxLengthError")]
        public string Password { get; set; }
    
        [Display(Name = "ConfirmPassword", ResourceType = typeof(DisplayNameResource))]
        [Required(ErrorMessageResourceName = "RequiredError", ErrorMessageResourceType = typeof(ErrorMessageResource))]
        [StringLength(50, MinimumLength = 6, ErrorMessageResourceType = typeof(ErrorMessageResource), ErrorMessageResourceName = "MinxMaxLengthError")]
        [Compare("Password", ErrorMessageResourceName = "PasswordConfirmMisMatch", ErrorMessageResourceType = typeof(ErrorMessageResource))]
        public string ConfirmPassword { get; set; }
    }
