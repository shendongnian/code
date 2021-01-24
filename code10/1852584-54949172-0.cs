    public class CustomerModel : IValidatableObject
    {
        public bool Subscribe {get; set;}
        public string Email {get; set;}
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (!Subscribe) 
            {
                yield return new ValidationResult("Please subscribe");
            }
            if (//not valid email address)
            {
                yield return new ValidationResult("Please enter valid email address");
            }
        }
    }
