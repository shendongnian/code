    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        var input = value as Address;
    
        if (string.IsNullOrEmpty(input.City))
            return new ValidationResult("City is required", new List<string>(){"City"});
    
        if (!string.IsNullOrEmpty(input.PostalCode))
            if (string.IsNullOrEmpty(input.Street))
                return new ValidationResult("Stret is required", new List<string>(){"Street"});
    
        return ValidationResult.Success;
    }
