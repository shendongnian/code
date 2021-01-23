    IEnumerable<modelvalidator> validators = ModelValidatorProviders.Providers.GetValidators(ViewData.ModelMetadata, ViewContext);
    ModelClientValidationRule rule = validators.SelectMany(v => v.GetClientValidationRules()).FirstOrDefault(m => m.ValidationType == "stringLength");
    if (rule != null && rule.ValidationParameters.ContainsKey("maximumLength"))
    {
       var maxLength = rule.ValidationParameters["maximumLength"];
    }
