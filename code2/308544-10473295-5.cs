    public class ClassA
    {
        [Required]
        public string Name { get; set; }
        public ClassB CBProp { get; set; }
    }
    public class ClassB:IValidatableObject
    {
        [Required]
        public string MyProperty { get; set; }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (!string.IsNullOrWhiteSpace(MyProperty) && MyProperty.Length > 10)
                yield return new ValidationResult("MaxLength reached");
        }
    }
