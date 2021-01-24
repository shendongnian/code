    private const string StartDateBefore = "StartTime should before than EndTime and EndTime2";
    private const string StartDateEqual = "StartTime is equal to EndTime";
    public bool CheckIfEqual { get; set; }
    protected override ValidationResult IsValid(object startTime, ValidationContext validationContext)
    {
        var endTimePropertyValue = validationContext.ObjectType.GetProperty(EndTimePropertyName)
                .GetValue(validationContext.ObjectInstance);
        if (startTime != null && startTime is DateTime
            & endTimePropertyValue != null && endTimePropertyValue is DateTime)
        {
            DateTime startDateTime = (DateTime)startTime;
            DateTime endDateTime = (DateTime)endTimePropertyValue;
            if (CheckIfEqual && startDateTime == endDateTime)
            {
                return new ValidationResult(StartDateEqual); //error message when dates are equal
            }
            else if (startDateTime > endDateTime)
            {
                return new ValidationResult(StartDateBefore); //error message when start date is after enddate
            }
        }
        return ValidationResult.Success;
    }
