     public class EmailsCustomAttribute : ValidationAttribute
        {
            public EmailsCustomAttribute(string pattern)
            {
                this.Pattern = pattern;
            }
    
            public string Pattern { get; }
    
            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                Regex regex = new Regex(Pattern);
                List<string> emails = value as List<string>;
                string errorMessage = string.Empty;
                foreach (var item in emails)
                {
                    if (!regex.IsMatch(item))
                    {
                        errorMessage += this.ErrorMessage.Replace("{0}", item);
                    }
                }
                ValidationResult validationResult = new ValidationResult(errorMessage);
    
                return validationResult;
            }
        }
