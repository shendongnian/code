    public partial class ObjectWithAStartAndEndDate : IValidatableObject
    {
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (this.StartDate >= this.EndDate)
            {
                yield return new ValidationResult("Start and End dates cannot overlap.");
            }
        }
    }
