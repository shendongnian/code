    public class Report : ValidationAttribute
        {
            public int Score { get; set; }
            public string Comment { get; set; }
            public int[] ReasonIds { get; set; }
    
            protected override ValidationResult IsValid(
            object value, ValidationContext validationContext)
            {
                if(Score < 4 && (string.IsNullOrEmpty(Comment) || ReasonIds.Count() < 1))
                {
                    return new ValidationResult(GeScoreErrorMessage());
                }
                return ValidationResult.Success;
            }
    
            private string GeScoreErrorMessage()
            {
                return $"If Score < 4 Comment and Reasons must be provided";
            }
        }
