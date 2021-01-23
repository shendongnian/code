    protected override IEnumerable<ValidationResult> Validate(PlayerModel entity, IValidationProvider validationProvider)
    {
        foreach (var result in ValidationResultHelper.IsRequired(entity.Profile.FirstName, "First Name"))
            yield return result;
        if (string.IsNullOrWhiteSpace(entity.Profile.LastName))
            yield return new Required("Last Name");
    }
