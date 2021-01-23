    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        if( EndDate <= StartDate )
            yield return new ValidationResult("EndDate must be grater than StartDate");
    }
