    public IEnumerable<ModelClientValidation> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
    {
        var rule = new ModelCLientValidationRule();
        rule.ErrorMessage = FormatErrorMessage(metadata.GetDisplayName());
        rule.ValidationType = "greater"; // This is what the jQuery.Validation expects
        rule.ValidationParameters.Add("other", OtherPropertyName); // This is the 2nd parameter
    
        yield return rule;
    }
