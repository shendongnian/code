    public class IbanValidationAttribute : ValidationAttribute
    {
        private readonly string _errorMessage;
        public IbanValidationAttribute(string errorMessage)
        {
            _errorMessage = errorMessage;
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            ErrorMessageTranslationService errorTranslation = validationContext.GetService(typeof(ErrorMessageTranslationService)) as ErrorMessageTranslationService;
            
            return IbanValidator.Validate(value as string)
                ? ValidationResult.Success
                : new ValidationResult(errorTranslation.GetLocalizedError(_errorMessage));
        }
    }
