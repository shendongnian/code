    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (!string.IsNullOrWhiteSpace(MyProperty) && MyProperty.Length > 10)
                yield return new ValidationResult("MaxLength reached", new List<string> { "MyProperty" });
        }
