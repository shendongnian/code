    IEnumerable<ModelValidator> validators = ModelValidatorProviders.Providers
        .GetValidators(ViewData.ModelMetadata, ViewContext);
    ModelClientValidationRule rule = validators.SelectMany(v => 
        v.GetClientValidationRules()
    ).FirstOrDefault(m => m.ValidationType == "length");
    if (rule != null && rule.ValidationParameters.ContainsKey("max")) {
        var maxLength = rule.ValidationParameters["max"];
    }
