    public class PortPolicy : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if ((int)value >= 1 && (int)value <= 65535)
            {
                return ValidationResult.Success;
            }
            else
            {
                return new ValidationResult("Invalid value");
            }
        }
    }
