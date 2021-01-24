[Required]
[RegularExpression(@"[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,4}")]
public string Email { get; set; }
[Compare (nameof(Email), ErrorMessage = "The Email and Confirm Email fields do not match.")]    
public string EmailConfirm { get; set; }
