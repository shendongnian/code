    public class ValidGuidAttribute : ValidationAttribute
    {
        private const string DefaultErrorMessage = "'{0}' does not contain a valid guid";
     
        public ValidGuidAttribute() : base(DefaultErrorMessage)
        {
        }
     
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var input = Convert.ToString(value, CultureInfo.CurrentCulture);
     
            // let the Required attribute take care of this validation
            if (string.IsNullOrWhiteSpace(input))
            {
                return null;
            }
     
            // get all of your guids (assume a repo is being used)
            var guids = new GuidRepository().AllGuids();
      
            Guid guid;
            if (!Guid.TryParse(input, out guid))
            {
                // not a validstring representation of a guid
                return new ValidationResult(FormatErrorMessage(validationContext.DisplayName));
            }
           
            // is the passed guid one we know about?
            return guids.Any(g => g == guid) ?
                new ValidationResult(FormatErrorMessage(validationContext.DisplayName)) : null;
        }
    }
