    public class Test: IValidatableObject
    {
        public int Id { get; set; }
        public string TravelDate { get; set; }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            DateTime dateTime;
            bool isDateTime = false;
            isDateTime = DateTime.TryParse(TravelDate, out dateTime);
            if (isDateTime)
            {
                yield return new ValidationResult($"TravelDate should be a string",new[] { "TravelDate" });
            }
        }
    }
