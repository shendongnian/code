    [CustomValidation(typeof(Customer), "ValidateRelatedObject")]
    public CustomerDetails Details
    {
        get;
        private set;
    }
    public static ValidationResult ValidateRelatedObject(object value, ValidationContext context)
    {
        var context = new ValidationContext(value, validationContext.ServiceContainer, validationContext.Items);
        var results = new List<ValidationResult>();
        Validator.TryValidateObject(value, context, results);
        // TODO: Wrap or parse multiple ValidationResult's into one ValidationResult
        return result;
    }
