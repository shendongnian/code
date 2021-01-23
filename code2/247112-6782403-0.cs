    [AttributeUsage(AttributeTargets.Property, AllowMultiple = true)]
    public class ReminderFormatAttribute: ValidationAttribute, IClientValidatable
    {
        public string DurationProperty { get; set; }
    
        public ReminderFormatAttribute(string durationProperty)
        {
            DurationProperty = durationProperty;
            ErrorMessage = "{0} value doesn't work for selected duration";
        }
    
        public override string FormatErrorMessage(string propName)
        {
            return string.Format(ErrorMessage, propName);
        }
    
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var durationType = validationContext.ObjectType.GetProperty(DurationProperty).GetValue(validationContext.ObjectInstance, null);
            var reminderLength = value;
    
            // Do your switch statement on durationType here
            // Here is a sample of the correct return values
            switch (durationType)
            {
                case DurationTypes.Days:
                    if (reminderLength > 30)
                    {
                        return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
                    }
                    else
                    {
                        return null;
                    }
            }
        }
    
        public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            var rule = new ModelClientValidationRule
                          {
                            ErrorMessage = FormatErrorMessage(metadata.GetDisplayName()),
                            ValidationType = "reminderformat",
                          };
            rule.ValidationParameters["durationproperty"] = DurationProperty;
            yield return rule;
        } 
    }
