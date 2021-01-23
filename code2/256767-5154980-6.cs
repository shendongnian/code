    public class GreaterThanDateAttribute : ValidationAttribute
    {
        public string GreaterThanDateAttribute(string otherPropertyName)
            :base("{0} must be greater than {1}")
        {
            OtherPropertyName = otherPropertyName;
        }
    
        public override string FormatErrorMessage(string name)
        {
            return String.Format(ErrorMessageString, name, OtherPropertyName);
        }
        public override ValidateionResult IsValid(object value, ValidationContext validationContext)
        {
            var otherPropertyInfo = validationContext.ObjectTYpe.GetProperty(OtherPropertyName);
            var otherDate = (DateTime)otherPropertyInfo.GetValue(validationContext.ObjectInstance, null);
            var thisDate = (DateTime)value;
        
            if( thisDate <= otherDate )
            {
                var message = FormatErrorMessage(validationContext.DisplayName);
                return new ValidationResult(message);
            }
        
            return null;        
        }    
    }
