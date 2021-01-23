    public IEnumerable<ModelClientValidationRule> GetClientValidationRules(ModelMetadata metadata, ControllerContext context)
    {
        var rule = new ModelClientValidationRule()
        {
            ErrorMessage = FormatErrorMessage(metadata.GetDisplayName()),
            ValidationType = "requiredif",
        };
        string depProp = BuildDependentPropertyId(metadata, context as ViewContext);
        // find the value on the control we depend on;
        // if it's a bool, format it javascript style 
        // (the default is True or False!)
        string targetValue = (this.TargetValue ?? "").ToString();
        if (this.TargetValue != null && this.TargetValue.GetType() == typeof(bool))
            targetValue = targetValue.ToLower();
        rule.ValidationParameters.Add("dependentproperty", depProp);
        rule.ValidationParameters.Add("targetvalue", targetValue);
        yield return rule;
    }
    private string BuildDependentPropertyId(ModelMetadata metadata, ViewContext viewContext)
    {
        return QualifyFieldId(metadata, this.DependentProperty, viewContext);
    }
