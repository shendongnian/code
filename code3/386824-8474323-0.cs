    public class NotEqualToAttribute : ValidationAttribute
    {
        private const string defaultErrorMessage = "{0} cannot be the same as {1}.";
        private string otherProperty;
        public NotEqualToAttribute(string otherProperty) : base(defaultErrorMessage)
        {
            if (string.IsNullOrEmpty(otherProperty))
            {
                throw new ArgumentNullException("otherProperty");
            }
            this.otherProperty = otherProperty;
        }
        public override string FormatErrorMessage(string name)
        {
            return string.Format(ErrorMessageString, name, otherProperty);
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value != null)
            {
                PropertyInfo otherPropertyInfo = validationContext.ObjectInstance.GetType().GetProperty(otherProperty);
                if (otherPropertyInfo == null)
                {
                    return new ValidationResult(string.Format("Property '{0}' is undefined.", otherProperty));
                }
                var otherPropertyValue = otherPropertyInfo.GetValue(validationContext.ObjectInstance, null);
                if (otherPropertyValue != null && !string.IsNullOrEmpty(otherPropertyValue.ToString()))
                {
                    if (value.Equals(otherPropertyValue))
                    {
                        return new ValidationResult(this.FormatErrorMessage(validationContext.DisplayName));
                    }
                }
            }
            return ValidationResult.Success;
        }        
    }
