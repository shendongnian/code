    public class PageViewModel : IValidatableObject
    {
        public bool? HasControl { get; set; }
        public bool? Critical { get; set; }
        public string Description { get; set; }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> errors = new List<ValidationResult>();
            if (HasControl == true)
            {
                if (Critical == null)
                    errors.Add(new ValidationResult($"{nameof(Critical)} is Required.", new List<string> { nameof(Critical) }));
                if (string.IsNullOrWhiteSpace(Description))
                    errors.Add(new ValidationResult($"{nameof(Description)} is Required.", new List<string> { nameof(Description) }));
            }
            return errors;
        }
    }
