    public partial class MyObjectModel : IValidatableObject
    {
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (someNumberProperty > anotherNumberProperty) 
                yield return new ValidationResult(
                        "someNumber property is larger than anotherNumberProperty", 
                                                  new[] { "someNumberProperty" });
            if (someNumberProperty == 0) 
                yield return new ValidationResult("someNumber property cannot be 0", 
                                                    new[] { "someNumberProperty" });
            
        }
    }
