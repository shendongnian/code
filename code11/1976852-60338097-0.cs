        using System.Web.Mvc;
        . . . .
        [Required(ErrorMessage = "This field is required.")]    
        public string NewPassword { get; set; }
        [Required(ErrorMessage = "This field is required.")]
        [Compare(nameof(NewPassword), ErrorMessage = "Passwords don't match.")]
        public string NewPasswordConfirm{ get; set; }
