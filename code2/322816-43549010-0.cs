    public class MaxLengthClientValidator : DataAnnotationsModelValidator<MaxLengthAttribute>
    {
        private readonly string _errorMessage;
        private readonly int _length;
        public MaxLengthClientValidator(ModelMetadata metadata, ControllerContext context, MaxLengthAttribute attribute)
        : base(metadata, context, attribute)
        {
            _errorMessage = attribute.FormatErrorMessage(metadata.DisplayName);
            _length = attribute.Length;
        }
        public override IEnumerable<ModelClientValidationRule> GetClientValidationRules()
        {
            var rule = new ModelClientValidationRule
            {
                ErrorMessage = _errorMessage,
                ValidationType = "length"
            };
            rule.ValidationParameters["max"] = _length;
            yield return rule;
        }
    }
