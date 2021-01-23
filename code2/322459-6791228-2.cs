    public class myModel : IValidatableObject
    {
          public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
          {
    
                if (string.IsNullOrEmpty(input.City))
                      yield return new ValidationResult("City is required",new string[]{"prop1","prop2"});
                if (!string.IsNullOrEmpty(input.PostalCode))
                      if (string.IsNullOrEmpty(input.Street))
                            yield return new ValidationResult("Stret is required");
          }
