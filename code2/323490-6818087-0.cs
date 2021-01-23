    new ValidationRuleInstance<DetailsPresenter>(
        new FailIfTrueRule<DetailsPresenter>(m => 
    {
        DateTime value;
    
        if(DateTime.TryParse(m.StartDate, out value))
        {
            return value.AddDays(1) < DateTime.Now;
        }
        else // parsing failed, return whatever value is appropriate
        {
    
        }
    } ,"StartDate"),
        new ValidationRuleInterpretation(Severity.Failure, "StartDateCannotBeInThePast", "Your start date cannot be in the past")
    ),
