    using System.Web.Mvc;
.
.
.
.
    [Required(ErrorMessage = "This field is required.")]    
    public string NewPassword { get; set; }
    [Required(ErrorMessage = "This field is required.")]
    [CompareAttribute("NewPassword", ErrorMessage = "Passwords don't match.")]
    public string RepeatPassword { get; set; }
