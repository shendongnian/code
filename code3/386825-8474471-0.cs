    public class MyClass : IValidateableObject
    {
        public string NewPassword { get; set; } 
        public string OldPassword { get; set; } 
    
        public IEnumerable<ValidationResult> Validate(ValidationContext context)
        {
           if (NewPassword == OldPassword)
              yield return new ValidationResult("Passwords should not be the same");
        }
    }
