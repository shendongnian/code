    public class B : IValidatableObject
    {
        public string Name { get; set; }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();
            if (string.IsNullOrEmpty(Name)) {
                errors.Add(new ValidationResult("Please enter your name"));
            }
            return errors;
        }
    }
