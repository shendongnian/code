    public class AnotherClass : IValidatableObject
    {
        [Required]
        public string anotherName { get; set; }
        [Required]
        public List<ThirdClass> third { get; set; }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (third.Any(x => string.IsNullOrWhiteSpace(x.foo3)
                            || string.IsNullOrWhiteSpace(x.four?.foo4)
                            || string.IsNullOrWhiteSpace(x.four?.bar4)))
            {
                yield return new ValidationResult("Invalid");
            }
        }
    }
