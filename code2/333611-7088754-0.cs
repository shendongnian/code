    public override IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        var validations = new List<ValidationResult>();
        if (From.HasValue && From > Until)
        {
            validations.Add(new ValidationResult("StartDateMustBeBeforeEndDate"));
        }
        return validations;
    }
