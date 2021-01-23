      public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
      {   
        if (string.IsNullOrEmpty(LastName))
        {
          yield return new ValidationResult("Enter valid lastname por favor", new[] { "LastName" });
        }
    
        if (string.IsNullOrEmpty(FirstName))
        {
          yield return new ValidationResult("Enter valid firstname por favor.", new[] { "FirstName" });
        }
      }
