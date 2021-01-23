    public class EmailAttribute : RegularExpressionAttribute
    {
        private const string defaultErrorMessage = "'{0}' must be a valid email address";
        public EmailAttribute() : 
            base("^[a-z0-9_\\+-]+(\\.[a-z0-9_\\+-]+)*@[a-z0-9]+(\\.[a-z0-9]+)*\\.([a-z]{2,4})$")
        { }
        public override string FormatErrorMessage(string name)
        {
            return string.Format(defaultErrorMessage, name);
        }
        protected override ValidationResult IsValid(object value,
                                                ValidationContext validationContext)
        {
            if (value != null)
            {
                if (!base.IsValid(value))
                {
                    return new ValidationResult(
                        FormatErrorMessage(validationContext.DisplayName));
                }
            }
            return ValidationResult.Success;
        }
    }
