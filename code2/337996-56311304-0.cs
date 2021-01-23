    public class MyModel : IValidatableObject // Implement IValidatableObject
    {
        [Required]
        public string Name {get; set;}
        public Guid SomeGuid {get; set;}
        ... other properties here
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (SomeGuid == default)
            {
                yield return new ValidationResult(
                    "SomeGuid must be provided",
                    new[] { nameof(SomeGuid) });
            }
        }
     }
