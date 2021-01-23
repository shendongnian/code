    public class ValidEmailAttribute : ValidationAttribute, IClientValidatable
    {
        // ...
    
        public IEnumerable GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
        {
            yield return new ModelClientValidationRule
            {
                ErrorMessage = FormatErrorMessage(metadata.DisplayName),
                ValidationType = "validemail"
            };
        }
    }
