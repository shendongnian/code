     public class Validate
    {
        public static ValidationResult Validate(Foo obj, ValidationContext vc)
        {
             return ValidationResult.Success;
             //or return new ValidationResult("Error"); 
        }
    }
