    public class CustomStringLength : StringLengthAttribute
    {
        public CustomStringLength(int maximumLength) 
            : base(maximumLength)
        {
        }
        public override string FormatErrorMessage(string name)
        {
            
            return base.FormatErrorMessage(name);
        }
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var propertyName = validationContext.DisplayName;
            var propertyAttribute = validationContext.ObjectType
                                        .GetProperty(propertyName)
                                        .GetCustomAttribute(typeof(ModelBinderAttribute));
            if (propertyAttribute is ModelBinderAttribute modelBinderAttribute)
            {
                validationContext.DisplayName = modelBinderAttribute.Name;
            }
            //validationContext.DisplayName = "Id";
            return base.IsValid(value, validationContext);
        }
    }
