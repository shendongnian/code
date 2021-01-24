    public class CustomValidationAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(
             object value, ValidationContext validationContext)
        {
            // validationContext.GetService() ... 
        }
    }
 
