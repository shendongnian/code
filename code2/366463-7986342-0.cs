     public class ValidationResult
    {        
        public List<ValidationResultItem> ValidationResultItems { get; set; }
        public bool IsAcceptable
        {
            get { return (ValidationResultItems == null || !ValidationResultItems.Any(vri => !vri.IsAcceptable)); }
        }       
        public void Add(ValidationResultItem propertyValidationResultItem)
        {
            ValidationResultItems.Add(propertyValidationResultItem);
        }
        public void Add(IEnumerable<ValidationResultItem> validationResultItems)
        {
            ValidationResultItems.AddRange(validationResultItems);
        }       
    }
