    [AttributeUsage(AttributeTargets.Property)]
    public class UnlikeAttribute : ValidationAttribute, IClientModelValidator
    {
        private string DependentProperty { get; }
        public UnlikeAttribute(string dependentProperty)
        {
            if (string.IsNullOrEmpty(dependentProperty))
            {
                throw new ArgumentNullException(nameof(dependentProperty));
            }
            DependentProperty = dependentProperty;
        }
        protected override ValidationResult IsValid(object value,
            ValidationContext validationContext)
        {
            if (value != null)
            {
                var otherProperty = validationContext.ObjectInstance.GetType().GetProperty(DependentProperty);
                var otherPropertyValue = otherProperty.GetValue(validationContext.ObjectInstance, null);
                if (value.Equals(otherPropertyValue))
                {
                    return new ValidationResult(ErrorMessage = ErrorMessage);
                }
            }
            return ValidationResult.Success;
        }
        public void AddValidation(ClientModelValidationContext context)
        {
            MergeAttribute(context.Attributes, "data-val", "true");
            MergeAttribute(context.Attributes, "data-val-unlike", ErrorMessage);
            MergeAttribute(context.Attributes, "data-val-unlike-property", DependentProperty);
        }
        private void MergeAttribute(IDictionary<string, string> attributes,
            string key,
            string value)
        {
            if (attributes.ContainsKey(key))
            {
                return;
            }
            attributes.Add(key, value);
        }
    }
