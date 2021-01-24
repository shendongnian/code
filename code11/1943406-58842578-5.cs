    public sealed class DateAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (validationContext == null)
            {
                throw new ArgumentNullException(nameof(validationContext));
            }
            if (!(value is DateTime))
            {
                return new ValidationResult($"Not a DateTime object ({value}).");
            }
            DateTime date = (DateTime)value;
            if (date.Date != date)
            {
                return new ValidationResult($"Do not specify the time ({value}).");
            }
            return ValidationResult.Success;
        }
    }
