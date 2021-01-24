    public string ErrorMessage2 { get; set; }
    protected override ValidationResult IsValid(object startTime, ValidationContext validationContext)
    {
        var endTimePropertyValue = validationContext.ObjectType.GetProperty(EndTimePropertyName)
                .GetValue(validationContext.ObjectInstance);
        if (startTime != null && startTime is DateTime
            & endTimePropertyValue != null && endTimePropertyValue is DateTime)
        {
            DateTime startDateTime = (DateTime)startTime;
            DateTime endDateTime = (DateTime)endTimePropertyValue;
            //if second error message is not empty we check if date are the same
            bool checkIfEqual = !string.IsNullOrEmpty(ErrorMessage2);
            if (checkIfEqual && startDateTime == endDateTime)
            {
                return new ValidationResult(ErrorMessage2);
            }
            else if (startDateTime > endDateTime)
            {
                return new ValidationResult(ErrorMessage);
            }
        }
        return ValidationResult.Success;
    }
