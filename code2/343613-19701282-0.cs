    [Localizable(false),AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
    public class RequiredIfAttribute : RequiredAttribute
    {
        public string BoolProperty { get; private set; }
        public RequiredIfAttribute(string boolProperty)
        {
            BoolProperty = boolProperty;
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (!Equals(value, null) || !string.IsNullOrEmpty(value as string))
                return ValidationResult.Success;
            var boolProperty = validationContext.ObjectInstance.GetType().GetProperty(BoolProperty);
            var boolValue = (bool)boolProperty.GetValue(validationContext.ObjectInstance, null);
            if (!boolValue)
                return ValidationResult.Success;
            return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
        }
    }
