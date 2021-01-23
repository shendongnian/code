    private static void AddIfRequired(string text, string name, List<ValidationResult> validationResults)
    {
        if (ValidatorHelper.IsRequired(text))
            requiredList.Add(new Required(name));
    }
    protected override IEnumerable<ValidationResult> Validate(PlayerModel entity, IValidationProvider validationProvider)
    {
        List<ValidationResult> validationResults = new List<ValidationResult>();
        AddIfRequired(entity.Profile.FirstName, "First Name", validationResults);
        AddIfRequired(entity.Profile.LastName, "Last Name", validationResults);
        // ...
        return validationResults;
    }
