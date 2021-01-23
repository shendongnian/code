    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
          if (String.IsNullOrEmpty(_PhonePart1) || String.IsNullOrEmpty(_PhonePart2)
                || String.IsNullOrEmpty(_PhonePart3))
          {
               yield return new ValidationResult("You must enter all " + 
                      "three parts of the number.");
          }
    }
