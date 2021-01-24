    public class CalendarAvailabilityRequestValidator : 
    AbstractValidator<CalendarAvailabilityRequest> 
    {
      public CalendarAvailabilityRequestValidator() 
      {
        RuleFor(request => request.StartDate)
            .Must(BeAValidDateFormat).WithMessage("Date must follow the format: yyyy-mm-dd")
            .NotNull().WithMessage("A start date must be provided.");
      }
    
      // will only match yyyy-mm-dd
      private static bool BeAValidDateFormat(string date)
        => Regex.IsMatch(date, "2\d{3}\-(0[1-9]|1[012])\-(0[1-9]|[12][0-9]|3[01])$", RegexOptions.Compiled);
    }
