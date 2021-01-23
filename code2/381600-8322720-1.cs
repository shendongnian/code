    public class GlobalResourceTypeResourceDataAnnotationsModelValidator : DataAnnotationsModelValidator<ValidationAttribute>
    {
        public GlobalResourceTypeResourceDataAnnotationsModelValidator(
            ModelMetadata metadata, 
            ControllerContext context, 
            ValidationAttribute attribute
        )
            : base(metadata, context, attribute)
        {
            if (Attribute.ErrorMessageResourceType == null)
            {
                Attribute.ErrorMessageResourceType = typeof(ModelValidationMessages);
            }
        }
    }
