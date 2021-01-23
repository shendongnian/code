    public class MinimumElementsAttribute : ValidationAttribute
    {
        private readonly int minElements;
        
        public MinimumElementsAttribute(int minElements)
        {
            this.minElements = minElements;
        }
       
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            var list = value as IList;
            var result = list?.Count >= minElements;
            return result
                ? ValidationResult.Success
                : new ValidationResult($"{validationContext.DisplayName} requires at least {minElements} element" + (minElements > 1 ? "s" : string.Empty));
        }
    }
