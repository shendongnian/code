    public class ValidationViewModel
    {
        [StringLength(1, ErrorMessage = "The {0} must be at least {2} characters long.", MinimumLength = 1)]
        [RegularExpression("^[0-9]$", ErrorMessage = "Only sigle number allowed between 0-9")]
        [DataType(DataType.Password)]
        [Display(Name = "Password")]
        public string Password { get; set; }
    }
