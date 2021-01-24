    public class StartWithRule : ValidationRule
    {
        public string Prefix { get; set; }
        public override ValidationResult Validate(object value, CultureInfo cultureInfo)
        {
            // Pass the value to string
            var numberToCheck = (string) value;
            if (numberToCheck == null) return ValidationResult.ValidResult;
            // Check if it starts with prefix
            return numberToCheck.StartsWith(Prefix)
                ? new ValidationResult(false, $"Starts with {Prefix}")
                : ValidationResult.ValidResult;
        }
    }
