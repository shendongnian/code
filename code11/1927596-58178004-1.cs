        [Required]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        [StringLength(Constants.MaxPasswordLength, ErrorMessage = "{0} must be  between {2} and {1} characters long", MinimumLength = Constants.MinPasswordLength)]
        public string Password { get; set; }
        [DataType(DataType.Password)]
        [Display(Name = "Confirm password")]
        [Compare("Password", ErrorMessage = "The password and confirmation password do not match")]
        public string ConfirmPassword { get; set; }
