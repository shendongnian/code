    public class ReversStringValidator : DataAnnotationsModelValidator<ReversStringMatchAttribute>
    {
        string property;
        public ReversStringValidator(ModelMetadata metadata, ControllerContext context, ReversStringMatchAttribute attribute)
            : base(metadata, context, attribute)
        {
            property = attribute.Property;
        }
        public override IEnumerable<ModelClientValidationRule> GetClientValidationRules()
        {
            var rule = new ModelClientValidationRule
            {
                ErrorMessage = Attribute.ErrorMessage,
                ValidationType = "reversStringValidator"
            };
            rule.ValidationParameters.Add("propertyname", property);
            return new[] { rule };
        }
    }
